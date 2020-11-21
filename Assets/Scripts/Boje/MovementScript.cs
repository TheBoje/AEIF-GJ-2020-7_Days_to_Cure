using System;
using UnityEditorInternal;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 _move = Vector3.zero;
    public float speed = 4f;
    public new Transform transform;
    public CharacterController characterController;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _move = transform.right * (x * speed) + transform.forward * (z * speed);
        _move.y = 0;
        
        characterController.Move(_move * Time.deltaTime);
    }

    private void Crouch()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch();
        }
    }
}