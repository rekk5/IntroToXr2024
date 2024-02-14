using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPosition : MonoBehaviour
{
    public InputActionReference action;
    public Vector3 externalPosition;
    private Vector3 room = new Vector3(0,2,0);
    // Start is called before the first frame update
    void start()
    {
        
        
        
    }
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (transform.position != externalPosition){
                transform.position = externalPosition;
            }else{
                transform.position = room;
            }
        };
    }


}
