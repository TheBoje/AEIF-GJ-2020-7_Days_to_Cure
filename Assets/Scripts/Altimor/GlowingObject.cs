using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingObject : MonoBehaviour
{
    public const int redCol = 210;
    public const int greenCol = 105;
    public const int blueCol = 10;

    private bool isFlashing;

    private void Start()
    {
        isFlashing = false;
    }

    public void StartFlash()
    {
        if (!isFlashing)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(redCol, greenCol, blueCol);
        }
    }

    public void StopFlash()
    {
        
    }
}
