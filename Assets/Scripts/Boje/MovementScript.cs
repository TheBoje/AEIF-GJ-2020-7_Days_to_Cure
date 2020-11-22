using System;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 _move = Vector3.zero;
    public float speed = 4f;
    public new Transform transform;
    public CharacterController characterController;
    private Boolean _isCrouch = false;
    private Transform _cameraTransform;

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
        if (!_isCrouch)
        {
            speed /= 2;
            var localPosition = _cameraTransform.localPosition;
            localPosition = new Vector3(localPosition.x, 0f, localPosition.z);
            _cameraTransform.localPosition = localPosition;
            _isCrouch = true;
        }
        else
        {
            var localPosition = _cameraTransform.localPosition;
            localPosition = new Vector3(localPosition.x, 0.81f, localPosition.z);
            _cameraTransform.localPosition = localPosition;
            speed *= 2;
            _isCrouch = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            Crouch();
        }
    }

    private void Start()
    {
        _cameraTransform = transform.Find("Camera");
    }
}