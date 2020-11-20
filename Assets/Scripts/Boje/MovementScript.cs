using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 _move;
    public float speed = 1f;
    [SerializeField] [Range(0f, 1f)] private float lerpCoef = 0.15f; // [0, 1]
    public new Transform transform;
    public Transform cameraTransform;
    
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        _move = transform.right * (x * speed) + transform.forward * (z * speed);
        var position = transform.position;
        position = Vector3.Lerp(position, position + _move, lerpCoef);
        transform.position = position;
    }
}