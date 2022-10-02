using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject playButton = null;
    [SerializeField] private GameObject quitButton = null;

    public void OnPlay()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}


