using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject zoomCamera;
    public GameObject mainCamera;
    private float fixedRotation = 0;

    void Update()
    {
        Vector3 mainCamRotation = mainCamera.transform.eulerAngles;
        Vector3 zoomCamRotation = new Vector3(mainCamRotation.x, mainCamRotation.y, fixedRotation);

        // Clamp the Euler angles to ensure they stay within the range of 0 to 360 degrees
        zoomCamRotation.x = Mathf.Clamp(zoomCamRotation.x, 0f, 360f);
        zoomCamRotation.y = Mathf.Clamp(zoomCamRotation.y, 0f, 360f);
        zoomCamRotation.z = Mathf.Clamp(zoomCamRotation.z, 0f, 360f);

        zoomCamera.transform.eulerAngles = zoomCamRotation;
    }
}
