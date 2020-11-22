using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_EndingScript : MonoBehaviour
{
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas looseCanvas;
    public GameObject gm;

    public void WIN()
    {
        transform.gameObject.SetActive(true);
        winCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Destroy(gm);
    }

    public void LOOSE()
    {
        transform.gameObject.SetActive(true);
        looseCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Destroy(gm);
    }
    
    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
