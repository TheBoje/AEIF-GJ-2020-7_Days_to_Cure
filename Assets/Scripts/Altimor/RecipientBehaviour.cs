using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipientBehaviour : MonoBehaviour
{
    [SerializeField] bool hasContent;
    [SerializeField] private String contentName;
    [SerializeField] private Color color;
    [SerializeField] private int dangerosity;
    public GameObject content;
    
    private void Start()
    {
        content.GetComponent<MeshRenderer>().enabled = hasContent;
        content.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public void Pouring()
    {
        hasContent = false;
        content.GetComponent<MeshRenderer>().enabled = hasContent;
    }
}
