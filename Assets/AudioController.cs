using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips = null;

    private AudioSource audioSource;
    private bool hasPlayedhint = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips[0], .5f);
    }
    private void Update()
    {
        if (!hasPlayedhint && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clips[1], .3f);
            hasPlayedhint = true;
        }
    }
    public void playAfterKey()
    {
        audioSource.PlayOneShot(clips[2], .5f);
    }
    public void playAfterKeyCard()
    {
        audioSource.PlayOneShot(clips[3], .5f);
    }
    public void playAfterButton()
    {
        audioSource.PlayOneShot(clips[4], .5f);
    }
    public void playAfterWin()
    {
        audioSource.PlayOneShot(clips[5], .5f);
    }
}
