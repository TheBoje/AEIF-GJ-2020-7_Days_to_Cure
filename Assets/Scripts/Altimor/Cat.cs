﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public void Pet()
    {
        transform.GetComponent<AudioSource>().Play();
    }
}
