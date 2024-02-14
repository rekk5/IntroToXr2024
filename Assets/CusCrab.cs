using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CusGrab : MonoBehaviour
{
    // Reference to the other hand
    private CusGrab otherHand = null;
    
    // List of nearby grabbable objects
    private List<Transform> nearObjects = new List<Transform>();
    
    // Reference to the currently grabbed object
    private Transform grabbedObject = null;
    
    // Reference to the input action
    public InputActionReference action;

    // Flag to track whether the grab action is currently pressed
    private bool isGrabbing = false;

    // Variables to track position and rotation for smooth movement
    private Vector3 previousPosition;
    private Quaternion previousRotation;

    private void Start()
    {
        // Enable the input action
        action.action.Enable();

        // Find the other hand
        foreach (CusGrab c in transform.parent.GetComponentsInChildren<CusGrab>())
        {
            if (c != this)
            {
                otherHand = c;
                break; // Once found, exit the loop
            }
        }
    }

    void Update()
    {
        isGrabbing = action.action.triggered;

        if (isGrabbing)
        {
            // Check if an object is grabbed
            if (!grabbedObject)
            {
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;
            }

            // Move the grabbed object
            if (grabbedObject)
            {
                Vector3 deltaPos = transform.position - previousPosition;
                Quaternion deltaRot = transform.rotation * Quaternion.Inverse(previousRotation);

                grabbedObject.position += deltaPos;
                grabbedObject.position = deltaRot * (grabbedObject.position - transform.position) + transform.position;
                grabbedObject.rotation = deltaRot * grabbedObject.rotation;
            }
        }
        else if (grabbedObject)
        {
            // Release the grabbed object
            grabbedObject = null;
        }

        // Update previous position and rotation
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        if (t && t.CompareTag("Grabbable"))
        {
            nearObjects.Add(t);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.CompareTag("Grabbable"))
        {
            nearObjects.Remove(t);
        }
    }
}