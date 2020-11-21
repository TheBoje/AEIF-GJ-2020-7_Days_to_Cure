using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
     private Collider trigger;
     [SerializeField] private Transform rotationAxe;
     [SerializeField] private float angle;
     [SerializeField] private Vector3 axe;

     private void Start()
     {
          trigger = gameObject.GetComponent<BoxCollider>();
     }

     private void OnTriggerStay(Collider other)
     {
          if (Input.GetButtonDown("Interact"))
          {
               trigger.enabled = false;
               transform.RotateAround(rotationAxe.position, axe, angle);
          }
     }
}
