using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
     private Collider trigger;
     [SerializeField] private Transform rotationAxe;
     [SerializeField] private float angle;

     private void Start()
     {
          trigger = gameObject.GetComponent<BoxCollider>();
     }

     private void OnTriggerStay(Collider other)
     {
          if (Input.GetButtonDown("Interact"))
          {
               trigger.enabled = false;
               gameObject.transform.RotateAround(rotationAxe.position, Vector3.up, angle);
          }
     }
}
