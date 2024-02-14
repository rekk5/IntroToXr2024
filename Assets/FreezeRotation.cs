using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public GameObject obj;
    private float fixedRotation = 0;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = obj.transform.eulerAngles;
        obj.transform.eulerAngles = new Vector3(rotation.x,  rotation.y, fixedRotation);
    }
}
