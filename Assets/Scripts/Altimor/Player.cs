using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private const float GRAB_DISTANCE = 1.5f;
    private const float HANDLE_POSITION_X = 0.4f;
    private const float HANDLE_POSITION_Y = -0.2f;
    private const float HANDLE_POSITION_Z = 0.8f;

    public GameObject gm;
    public Canvas UI;
    private GameManager gmScript;
    private InteractionScript UIscript;

    private Vector3 handlePos;
    public Transform eyes;
    public GameObject handleObject;
    private RecipientBehaviour rb;
    private Boolean _calendrierOuvert = false;

    public AudioClip drink;
    public AudioClip weakCought;
    public AudioClip strongCought;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        hasDoneSomething = false;
        handleObject = null;
        handlePos = new Vector3(HANDLE_POSITION_X, HANDLE_POSITION_Y, HANDLE_POSITION_Z);
        UIscript = UI.GetComponent<InteractionScript>();
        gmScript = gm.GetComponent<GameManager>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void Cought(bool strong = true)
    {
        if (strong)
            StartCoroutine(WaitForSound(strongCought));
        else
            StartCoroutine(WaitForSound(weakCought));
    }
    
    public void GrabObject()
    {
        RaycastHit spotedObject;
        if (handleObject == null && !_calendrierOuvert)
        {
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (spotedObject.transform.CompareTag("Recipient"))
                {
                    UIscript.draw_take(spotedObject.transform.gameObject.GetComponent<RecipientBehaviour>()
                        .ContentName);
                    if (Input.GetButtonDown("Interact"))
                    {
                        handleObject = spotedObject.transform.gameObject;
                        handleObject.transform.parent = eyes;
                        handleObject.transform.localPosition = handlePos;
                        handleObject.transform.rotation = Quaternion.identity;
                        rb = handleObject.GetComponent<RecipientBehaviour>();
                        UIscript.clear_take();
                        hasDoneSomething = true;
                    }
                }
                else if (spotedObject.transform.CompareTag("Calendrier"))
                {
                    UIscript.clear_take();
                    if (!_calendrierOuvert)
                    {
                        UIscript.draw_open_calendrier();
                        if (Input.GetButtonDown("Interact"))
                        {
                            transform.Find("UI").GetComponent<CalendrierManager>()
                                .AfficheCalendrier();
                            _calendrierOuvert = true;
                            UIscript.clear_open_calendrier();
                            hasDoneSomething = true;
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("Interact"))
                        {
                            transform.Find("UI").GetComponent<CalendrierManager>().CacheCalendrier();
                            _calendrierOuvert = false;
                            UIscript.clear_open_calendrier();
                            hasDoneSomething = true;
                        }
                    }
                }
                else
                {
                    UIscript.clear_take();
                    UIscript.clear_open_calendrier();
                }
            }
            else if (_calendrierOuvert && Input.GetButtonDown("Interact"))
            {
                transform.Find("UI").GetComponent<CalendrierManager>().CacheCalendrier();
                _calendrierOuvert = false;
                UIscript.clear_open_calendrier();
                UIscript.clear_take();
                hasDoneSomething = true;
            }
            else
            {
                UIscript.clear_open_calendrier();
                UIscript.clear_take();
            }
        }
        else if (_calendrierOuvert && Input.GetButtonDown("Interact"))
        {
            transform.Find("UI").GetComponent<CalendrierManager>().CacheCalendrier();
            _calendrierOuvert = false;
            UIscript.clear_open_calendrier();
            hasDoneSomething = true;
        }
        else
        {
            UIscript.clear_open_calendrier();
        }
    }

    public void DropObject()
    {
        if (handleObject && !hasDoneSomething)
        {
            RaycastHit spotedObject;
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (spotedObject.transform.CompareTag("Furniture"))
                {
                    UIscript.draw_put();
                    if (Input.GetButtonDown("Interact"))
                    {
                        handleObject.transform.parent = null;
                        handleObject.transform.position = spotedObject.point;
                        handleObject.transform.rotation = Quaternion.identity;
                        handleObject = null;
                        UIscript.clear_put();
                        hasDoneSomething = true;
                    }
                }
                else
                {
                    UIscript.clear_put();
                }
            }
            else
            {
                UIscript.clear_put();
            }
        }
    }

    public void PourObject()
    {
        if (handleObject && !hasDoneSomething)
        {
            RaycastHit spotedObject;
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (spotedObject.transform.CompareTag("Bowl"))
                {
                    if (rb.CanPour() && !spotedObject.transform.GetComponent<BowlBehaviour>().IsFull())
                    {
                        UIscript.draw_add();
                        if (Input.GetButtonDown("Interact"))
                        {
                            rb.Pouring(spotedObject.transform.gameObject);
                            hasDoneSomething = true;
                        }
                    }
                    else
                    {
                        UIscript.clear_add();
                    }
                }
                else
                {
                    UIscript.clear_add();
                }
            }
            else
            {
                UIscript.clear_add();
            }
        }
        else
        {
            UIscript.clear_add();
        }
    }

    public void Sleep()
    {
        RaycastHit spotedObject;
        if (!hasDoneSomething && Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE))
        {
            if (spotedObject.transform.CompareTag("Bed"))
            {
                UIscript.draw_sleep();
                if (Input.GetButtonDown("Interact"))
                {
                    gmScript.nextDay();
                    hasDoneSomething = true;
                }
            }
            else
            {
                UIscript.clear_sleep();
            }
        }
        else
        {
            UIscript.clear_sleep();
        }
    }

    public void Pet()
    {
        RaycastHit spotedObject;
        
        if (!hasDoneSomething && Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
            GRAB_DISTANCE) && !hasDoneSomething)
        {
            if (spotedObject.transform.CompareTag("Pet"))
            {
                UIscript.draw_pet();
                if (Input.GetButtonDown("Interact"))
                {
                    spotedObject.transform.gameObject.GetComponent<Cat>().Pet();
                    UIscript.clear_pet();
                    hasDoneSomething = true;
                }
            }
            else
            {
                UIscript.clear_pet();
            }
        }
        else
        {
            UIscript.clear_pet();
        }
    }

    IEnumerator WaitForSound(AudioClip sound)
    {
        audio.clip = sound;
        audio.Play();
        yield return new WaitForSeconds(sound.length);
    }

    public void DrinkBowl()
    {
        if (handleObject == null && !hasDoneSomething)
        {
            RaycastHit spotedObject;
            if (Physics.Raycast(eyes.position, eyes.TransformDirection(Vector3.forward), out spotedObject,
                GRAB_DISTANCE))
            {
                if (spotedObject.transform.CompareTag("Bowl"))
                {
                    UIscript.draw_drink();
                    if (Input.GetButtonDown("Interact"))
                    {
                        if (spotedObject.transform.GetComponent<BowlBehaviour>().IsFull())
                        {
                            StartCoroutine(WaitForSound(drink));
                            gmScript.Drink();
                            _hasDoneSomething = true;
                            UIscript.clear_drink();
                        }
                        else
                        {
                            Debug.Log("Le bol n'est pas plein");
                        }
                    }
                }            else
                {
                    UIscript.clear_drink();
                }
            }
            else
            {
                UIscript.clear_drink();
            }
        }
    }

    private void Update()
    {
        hasDoneSomething = false;
        GrabObject();
        DropObject();
        PourObject();
        Sleep();
        Pet();
        DrinkBowl();
    }
}