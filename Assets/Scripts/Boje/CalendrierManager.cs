using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendrierManager : MonoBehaviour
{
    private int journee = 0;
    [SerializeField] private Canvas calendrier;

    public void AddJour(string message)
    {
        calendrier.transform.Find($"Text ({journee.ToString()})").GetComponent<Text>().text = message;
        journee++;
    }

    public void AfficheCalendrier()
    {
        calendrier.gameObject.SetActive(true);
    }

    public void CacheCalendrier()
    {
        calendrier.gameObject.SetActive(false);
    }
}
