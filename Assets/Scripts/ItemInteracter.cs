using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemInteracter : MonoBehaviour
{
    [SerializeField] private GameObject InteractCanvas = null;
    [SerializeField] private TextMeshProUGUI InteractText = null;
    [SerializeField] private Transform playerHand = null;
    [SerializeField] private bool isGrabable = false;
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private Transform[] bars = null;
    [SerializeField] private AudioClip[] audioClips = null;
    [SerializeField] private GameObject cameraObject = null;
    private bool hasPlayedhint = false;

    private bool canInteract;
    private AudioSource audioSource;
    private void Start()
    {
        InteractCanvas.SetActive(false);
    }
    private void Update()
    {        
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
                        cameraObject.GetComponent<AudioController>().playAfterKey();
                    }
                    else if (gameObject.CompareTag("KeyCard"))
                    {
                        cameraObject.GetComponent<AudioController>().playAfterKeyCard();
                    }
                    else if (gameObject.CompareTag("Button"))
                    {
                        cameraObject.GetComponent<AudioController>().playAfterButton();
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
                    Destroy(gameObject);
                }
                
            }
            else if ( hasItem && isPlaceable)
            {
                InteractCanvas.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (gameObject.CompareTag("Button"))
                    {
                        cameraObject.GetComponent<AudioController>().playAfterWin();
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
                        StartCoroutine(LoadWinScene());
                    }
                }
                
            }
        }
    }
    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(17f);
        SceneManager.LoadScene("Final");
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
