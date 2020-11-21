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

    public Canvas UI;
    private  InteractionScript UIscript;
    
    private Vector3 handlePos;
    public Transform eyes;
    private GameObject handleObject;
    private RecipientBehaviour rb;

    // Start is called before the first frame update
    void Start()
    {
        handleObject = null;
        handlePos = new Vector3(HANDLE_POSITION_X, HANDLE_POSITION_Y, HANDLE_POSITION_Z);
        UIscript = UI.GetComponent<InteractionScript>();
    }

    public void GrabObject()
    {
        RaycastHit spotedObject;
        if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE))
        {
            if (spotedObject.transform.CompareTag("Recipient"))
            {
                UIscript.draw_take(spotedObject.transform.gameObject.GetComponent<RecipientBehaviour>().ContentName);
                if (Input.GetButtonDown("Interact"))
                {
                    handleObject = spotedObject.transform.gameObject;
                    handleObject.transform.parent = eyes;
                    handleObject.transform.localPosition = handlePos;
                    handleObject.transform.rotation = Quaternion.identity;
                    rb = handleObject.GetComponent<RecipientBehaviour>();
                }
            }
        }
        else
        {
            UIscript.clear_UI();
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
                if (spotedObject.transform.CompareTag("Furniture"))
                {
                    UIscript.draw_put();
                    if (Input.GetButtonDown("Fire1"))
                    {
                        handleObject.transform.parent = null;
                        handleObject.transform.position = spotedObject.point;
                        handleObject.transform.rotation = Quaternion.identity;
                        handleObject = null;
                    }
                }
            }
            else
            {
                UIscript.clear_UI();
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
                if (spotedObject.transform.CompareTag("Bowl"))
                {
                    UIscript.draw_add();
                    if (Input.GetButtonDown("Fire2"))
                    {
                        Debug.Log("Pour");
                        rb.Pouring(spotedObject.transform.gameObject);
                    }    
                }
            }
            else
            {
                UIscript.clear_UI();
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
