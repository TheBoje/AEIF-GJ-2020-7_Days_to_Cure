using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendrierManager : MonoBehaviour
{
    private int journee = 0;

    public void AddJour(string message)
    {
        transform.Find($"Text ({journee.ToString()})").GetComponent<Text>().text = message;
        journee++;
    }

    public void AfficheCalendrier()
    {
        transform.gameObject.SetActive(true);
    }

    public void CacheCalendrier()
    {
        transform.gameObject.SetActive(false);
    }
}
