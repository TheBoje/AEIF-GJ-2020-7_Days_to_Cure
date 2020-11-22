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
    private Material _baseMaterial;
    public GameObject content;
    
    private void Start()
    {
        _baseMaterial = new Material(AssetDatabase.LoadAssetAtPath<Material>("Assets/Prefab/TransparentMat.mat"));
        content.GetComponent<MeshRenderer>().enabled = hasContent;
        _baseMaterial.color = color;
        content.GetComponent<Renderer>().material = _baseMaterial;
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
