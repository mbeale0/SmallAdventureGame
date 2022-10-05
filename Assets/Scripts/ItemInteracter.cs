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
    // allow option to select if grabbing or placing
    // serialize field for hand and place objects(transforms probably

    private bool canInteract;

    private void Start()
    {
        InteractCanvas.SetActive(false);
    }
    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (isGrabable)
            {
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
            else if (isPlaceable)
            {
                // else placing
                // diable item in hand
                // activate item in scene
                // activate in scene action(door opening/winning)
            }


        }
    }
    private void OnMouseEnter()
    {
        InteractCanvas.SetActive(true);
        canInteract = true;
    }
    private void OnMouseExit()
    {
        InteractCanvas.SetActive(false);
        canInteract = false;
    }
}
