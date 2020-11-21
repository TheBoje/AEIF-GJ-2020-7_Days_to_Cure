using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private Canvas takeCanvas;
    [SerializeField] private Canvas drinkCanvas;
    [SerializeField] private Canvas openCanvas;
    [SerializeField] private Canvas putCanvas;
    [SerializeField] private Canvas addCanvas;
    [SerializeField] private Canvas openCalendrier;
    [SerializeField] private Canvas sleepCanvas;
    [SerializeField] private Canvas petCanvas;

    public void clear_UI()
    {
        takeCanvas.gameObject.SetActive(false);
        drinkCanvas.gameObject.SetActive(false);
        openCanvas.gameObject.SetActive(false);
        putCanvas.gameObject.SetActive(false);
        addCanvas.gameObject.SetActive(false);
        openCalendrier.gameObject.SetActive(false);
        sleepCanvas.gameObject.SetActive(false);
        petCanvas.gameObject.SetActive(false);
    }

    public void draw_take(string itemName)
    {
        clear_UI();
        takeCanvas.GetComponent<Transform>().Find("TextCanvas").Find("Action").GetComponent<Text>().text = $"Prendre {itemName}";
        takeCanvas.gameObject.SetActive(true);
    }
    
    public void draw_take()
    {
        clear_UI();
        takeCanvas.GetComponent<Transform>().Find("Action").GetComponent<Text>().text = $"Take";
        takeCanvas.gameObject.SetActive(true);
    }

    public void draw_drink()
    {
        clear_UI();
        drinkCanvas.gameObject.SetActive(true);
    }

    public void draw_open()
    {
        clear_UI();
        openCanvas.gameObject.SetActive(true);
    }

    public void draw_put()
    {
        clear_UI();
        putCanvas.gameObject.SetActive(true);
    }

    public void draw_add()
    {
        clear_UI();
        addCanvas.gameObject.SetActive(true);
    }

    public void draw_open_calendrier()
    {
        clear_UI();
        openCalendrier.gameObject.SetActive(true);
    }

    public void draw_sleep()
    {
        clear_UI();
        sleepCanvas.gameObject.SetActive(true);
    }

    public void draw_pet()
    {
        clear_UI();
        petCanvas.gameObject.SetActive(true);
    }
    private void Start()
    {
        clear_UI();
    }
}