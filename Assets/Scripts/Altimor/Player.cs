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
    public Transform eyes;
    private GameObject handleObject;
    private RecipientBehaviour rb;

    // Start is called before the first frame update
    void Start()
    {
        handleObject = null;
        handlePos = new Vector3(HANDLE_POSITION_X, HANDLE_POSITION_Y, HANDLE_POSITION_Z);
    }

    public void GrabObject()
    {
        RaycastHit spotedObject;
        if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE))
        {
            //Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * spotedObject.distance, Color.yellow);
            Debug.Log(spotedObject.transform.name);
            if (Input.GetButtonDown("Interact") && spotedObject.transform.CompareTag("Recipient"))
            {
                handleObject = spotedObject.transform.gameObject;
                handleObject.transform.parent = eyes;
                handleObject.transform.localPosition = handlePos;
                rb = handleObject.GetComponent<RecipientBehaviour>();
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

    public void PourObject()
    {
        if (handleObject)
        {
            RaycastHit spotedObject;
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    rb.Pouring();
                }
            }
        }
    }
    
    private void FixedUpdate()
    {
        GrabObject();
        DropObject();
        PourObject();
    }
}
