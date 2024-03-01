using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : Object
{
    //This script pauses and resumes the audio attached to the GameObject as selected.

    AudioClip audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioClip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SwitchOnOff() 
    {
        Debug.Log("On/Off...");

        if(audioSource.isPlaying)
        {
            audioSource.Pause();
        }     
        else if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }
}
