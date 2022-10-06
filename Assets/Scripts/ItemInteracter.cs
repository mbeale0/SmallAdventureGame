using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteracter : MonoBehaviour
{
    [SerializeField] private GameObject InteractCanvas = null;
    [SerializeField] private TextMeshProUGUI InteractText = null;
    [SerializeField] private Transform playerHand = null;
    [SerializeField] private bool isGrabable = false;
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private Transform[] bars = null;
    [SerializeField] private AudioClip[] audioClips = null;
    private bool hasPlayedhint = false;

    private bool canInteract;
    private AudioSource audioSource;
    private void Start()
    {
        InteractCanvas.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.PlayOneShot(audioClips[0], .3f);
    }
    private void Update()
    {
        if (!hasPlayedhint && !audioSource.isPlaying){
            audioSource.PlayOneShot(audioClips[1], .3f);
            hasPlayedhint = true;
        }
        bool hasItem = false;
        foreach (Transform child in playerHand)
        {
            if (child.CompareTag(tag))
            {
                if (child.gameObject.activeSelf){
                    hasItem = true;
                }
            }
        }
        if (canInteract)
        {
            if (isGrabable)
            {
                InteractCanvas.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.CompareTag("Key")){
                        audioSource.PlayOneShot(audioClips[2], .3f);
                    }
                    else if (gameObject.CompareTag("KeyCard"))
                    {
                        audioSource.PlayOneShot(audioClips[3], .3f);
                    }
                    else if (gameObject.CompareTag("Button"))
                    {
                        audioSource.PlayOneShot(audioClips[4], .3f);
                    }
                    InteractCanvas.SetActive(false);
                    foreach (Transform child in playerHand)
                    {
                        if (child.CompareTag(tag))
                        {
                            child.gameObject.SetActive(true);
                        }
                    }
                    
                    InteractCanvas.SetActive(false);
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                
            }
            else if ( hasItem && isPlaceable)
            {
                InteractCanvas.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.CompareTag("Button"))
                    {
                        audioSource.PlayOneShot(audioClips[5], .3f);
                    }
                    InteractCanvas.SetActive(false);
                    foreach (Transform child in playerHand)
                    {
                        if (child.CompareTag(tag))
                        {
                            child.gameObject.SetActive(false);
                        }


                    }
                    foreach (Transform child in gameObject.transform)
                    {
                        if (child.CompareTag(tag))
                        {
                            child.gameObject.SetActive(true);
                        }
                    }

                    if (gameObject.CompareTag("Key") || gameObject.CompareTag("KeyCard"))
                    {
                        GameObject door = gameObject.transform.parent.gameObject;
                        Destroy(door);
                    }
                    else if (gameObject.CompareTag("Button"))
                    {
                        foreach (Transform bar in bars)
                        {
                            float x = 0;
                            while(x < 5)
                            {
                                bar.Translate(Vector3.back * Time.deltaTime);
                                x += Time.deltaTime;
                            }
                            
                        }
                    }
                }
                
            }
        }
    }
    private void OnMouseOver()
    {
        canInteract = true;
    }
    private void OnMouseExit()
    {
        InteractCanvas.SetActive(false);
        canInteract = false;
    }
}
