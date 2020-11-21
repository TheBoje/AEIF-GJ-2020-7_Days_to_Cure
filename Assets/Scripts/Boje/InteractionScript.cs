using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private Image takeCanvas;
    [SerializeField] private Image drinkCanvas;
    [SerializeField] private Image openCanvas;
    [SerializeField] private Image putCanvas;
    [SerializeField] private Image addCanvas;

    public void clear_UI()
    {
        takeCanvas.gameObject.SetActive(false);
        drinkCanvas.gameObject.SetActive(false);
        openCanvas.gameObject.SetActive(false);
        putCanvas.gameObject.SetActive(false);
        addCanvas.gameObject.SetActive(false);
    }

    public void draw_take(string itemName)
    {
        clear_UI();
        takeCanvas.GetComponent<Transform>().Find("Action").GetComponent<Text>().text = $"Take {itemName}";
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

    private void Start()
    {
        clear_UI();
    }
}