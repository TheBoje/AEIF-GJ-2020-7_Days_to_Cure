using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject handleObject;
    private GameObject selectedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        handleObject = null;
    }

    private GameObject CastRay()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit) ? hit.transform.gameObject : null;
    }

    private void Update()
    {
        selectedObject = CastRay();
        if (selectedObject)
        {
            
        }
    }
}
