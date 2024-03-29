using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation;
    public Space rotationSpace = Space.Self;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime, rotationSpace);
    }
}
