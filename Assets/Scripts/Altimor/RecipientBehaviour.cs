using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RecipientBehaviour : MonoBehaviour
{
    [SerializeField] bool hasContent;
    [SerializeField] private String contentName;
    [SerializeField] private Color color;
    [SerializeField] private int dangerosity;
    public Material _baseMaterial;
    private Material actualMetarial;
    public GameObject content;
    [SerializeField] private bool emit = false;
    [SerializeField] private Color color_emit = Color.black;
    [SerializeField] private int intensity = 1;
    
    private void Start()
    {
        actualMetarial = new Material(_baseMaterial);
        content.GetComponent<MeshRenderer>().enabled = hasContent;
        actualMetarial.color = color;
        if (emit)
        {
            actualMetarial.DisableKeyword("_EMISSION");
            actualMetarial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            actualMetarial.SetColor("_EmissionColor", color_emit * intensity);
            actualMetarial.EnableKeyword("_EMISSION");
        }
        else
        {
            actualMetarial.DisableKeyword("_EMISSION");
        }
            
        content.GetComponent<Renderer>().material = actualMetarial;
    }

    public Boolean CanPour()
    {
        return hasContent;
    }
    
    public void Pouring(GameObject target)
    {
        BowlBehaviour bb = target.GetComponent<BowlBehaviour>();
        if (!bb.IsFull() && hasContent)
        {
            hasContent = false;
            content.GetComponent<MeshRenderer>().enabled = hasContent;
            bb.Fill(contentName, color, dangerosity);
        }
    }

    public string ContentName => contentName;
}
