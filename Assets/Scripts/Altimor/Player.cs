using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float GRAB_DISTANCE = 1.5f;
    private const float HANDLE_POSITION_X = 0.5f;
    private const float HANDLE_POSITION_Y = -0.5f;
    private const float HANDLE_POSITION_Z = 0.7f;
    
    private Vector3 handlePos;
    private Transform eyes;
    private GameObject handleObject;

    // Start is called before the first frame update
    void Start()
    {
        handleObject = null;
        eyes = transform.GetChild(0).transform;
        handlePos = new Vector3(HANDLE_POSITION_X, HANDLE_POSITION_Y, HANDLE_POSITION_Z);
    }

    public void GrabObject()
    {
        RaycastHit spotedObject;
        if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE))
        {
            Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * spotedObject.distance, Color.yellow);
            Debug.Log(spotedObject.transform.tag);
            if (Input.GetButtonDown("Interact") && spotedObject.transform.CompareTag("Recipient"))
            {
                handleObject = spotedObject.transform.gameObject;
                handleObject.transform.parent = eyes;
                handleObject.transform.localPosition = handlePos;
            }
        }
        else
        {
            Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }

    public void DropObject()
    {
        if (handleObject)
        {
            RaycastHit spotedObject;
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (Input.GetButtonDown("Fire1") && spotedObject.transform.CompareTag("Furniture"))
                {
                    handleObject.transform.parent = null;
                    handleObject.transform.position = spotedObject.point;
                    handleObject.transform.rotation = Quaternion.identity;
                    handleObject = null;
                }
            }
        }
    }
    
    private void FixedUpdate()
    {
        GrabObject();
        DropObject();
    }
}
