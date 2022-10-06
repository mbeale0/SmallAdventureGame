using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void OnPlay()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}


