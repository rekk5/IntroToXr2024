using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    //private float fixedRotation = 0;
   
   //private Vector3 offset = new Vector3(0, 0.3919578f, 0);

    // Update is called once per frame
    void Update()
    {
       
        obj1.transform.position = obj2.transform.position;
        
    }
}
