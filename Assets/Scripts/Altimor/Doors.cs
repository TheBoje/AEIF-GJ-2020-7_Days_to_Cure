using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
     private Collider trigger;
     private InteractionScript UIscript;
     [SerializeField] private Transform rotationAxe;
     [SerializeField] private float angle;
     [SerializeField] private Vector3 axe;
     private Boolean exist = true;
     private Player playerScript;

     private void Start()
     {
          trigger = gameObject.GetComponent<BoxCollider>();
          UIscript = GameObject.Find("/Player").transform.Find("UI").transform.Find("UI_interaction").GetComponent<InteractionScript>();
          playerScript = GameObject.Find("/Player").GetComponent<Player>();
     }

     private void OnTriggerStay(Collider other)
     {
          if (exist && playerScript.handleObject == null && playerScript.hasDoneSomething == false)
          {
               UIscript.draw_open();           
          }
          if (Input.GetButtonDown("Interact") && playerScript.handleObject == null && playerScript.hasDoneSomething == false)
          {
               trigger.enabled = false;
               exist = false;
               transform.RotateAround(rotationAxe.position, axe, angle);
               UIscript.clear_UI();
          }
     }

     private void OnTriggerExit(Collider other)
     {
          Debug.Log("Clearing UI open");
          UIscript.clear_UI();
     }
}
