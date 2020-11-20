using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float GRAB_DISTANCE = 1.0f;
    private const float HANDLE_POSITION_X = 0.5f;
    private const float HANDLE_POSITION_Y = -0.5f;
    private const float HANDLE_POSITION_Z = 0.7f;
    
    private Transform eyes;
    private GameObject handleObject;

    // Start is called before the first frame update
    void Start()
    {
        handleObject = null;
        eyes = transform.GetChild(0).transform;
    }

    private void FixedUpdate()
    {
        RaycastHit spotedObject;
        if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE))
        {
            Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * spotedObject.distance,
                Color.yellow);
            Debug.Log(spotedObject.transform.name);
            if (Input.GetButtonDown("Interact"))
            {
                handleObject = spotedObject.transform.gameObject;
                handleObject.transform.parent = eyes;
                handleObject.transform.localPosition = new Vector3(HANDLE_POSITION_X, HANDLE_POSITION_Y, HANDLE_POSITION_Z);
            }
        }
        else
        {
            Debug.DrawRay(eyes.position, eyes.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
