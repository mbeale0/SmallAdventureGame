using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteracter : MonoBehaviour
{
    [SerializeField] private GameObject InteractCanvas = null;
    [SerializeField] private TextMeshProUGUI InteractText = null;
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
            //if grabbing
                // Disableitem in scene
                // show item in hand:
                // for each child in characters hand
                    // if hadn item tag == this tag
                        // enable
            // else placing
                // diable item in hand
                // activate item in scene
                // activate in scene action(door opening/winning)
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
