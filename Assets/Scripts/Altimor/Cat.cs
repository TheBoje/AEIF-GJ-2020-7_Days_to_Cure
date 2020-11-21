using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<AudioSource>().playOnAwake = true;
    }


    public void Pet()
    {
        transform.GetComponent<AudioSource>().Play();
    }
}
