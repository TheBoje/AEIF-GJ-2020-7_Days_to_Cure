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
        clear_take();
        clear_drink();
        clear_open();
        clear_put();
        clear_add();
        clear_open_calendrier();
        clear_sleep();
        clear_pet();
    }

    public void draw_take(string itemName)
    {
        clear_UI();
        takeCanvas.GetComponent<Transform>().Find("TextCanvas").Find("Action").GetComponent<Text>().text = $"Prendre {itemName}";
        takeCanvas.gameObject.SetActive(true);
    }

    public void clear_take()
    {
        takeCanvas.gameObject.SetActive(false);
    }
    
    public void draw_take()
    {
        clear_UI();
        takeCanvas.GetComponent<Transform>().Find("Action").GetComponent<Text>().text = $"Prendre";
        takeCanvas.gameObject.SetActive(true);
    }

    public void draw_drink()
    {
        clear_UI();
        drinkCanvas.gameObject.SetActive(true);
    }
    
    public void clear_drink()
    {
        drinkCanvas.gameObject.SetActive(false);
    }

    public void draw_open()
    {
        clear_UI();
        openCanvas.gameObject.SetActive(true);
    }
    
    public void clear_open()
    {
        openCanvas.gameObject.SetActive(false);
    }

    public void draw_put()
    {
        clear_UI();
        putCanvas.gameObject.SetActive(true);
    }
    
    public void clear_put()
    {
        putCanvas.gameObject.SetActive(false);
    }

    public void draw_add()
    {
        clear_UI();
        addCanvas.gameObject.SetActive(true);
    }

    public void clear_add()
    {
        addCanvas.gameObject.SetActive(false);
    }
    
    public void draw_open_calendrier()
    {
        clear_UI();
        openCalendrier.gameObject.SetActive(true);
    }
    
    public void clear_open_calendrier()
    {
        openCalendrier.gameObject.SetActive(false);
    }

    public void draw_sleep()
    {
        clear_UI();
        sleepCanvas.gameObject.SetActive(true);
    }
    
    public void clear_sleep()
    {
        sleepCanvas.gameObject.SetActive(false);
    }

    public void draw_pet()
    {
        clear_UI();
        petCanvas.gameObject.SetActive(true);
    }
    
    public void clear_pet()
    {
        petCanvas.gameObject.SetActive(false);
    }
    private void Start()
    {
        clear_UI();
    }
}