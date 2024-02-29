using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : Object
{
    AudioClip audioClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioClip = GetComponent<AudioClip>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SwitchOnOff() 
    {
        //IsObjectSelected(false);

        Debug.Log("On/Off...");
        //Destroy(gameObject);

        if(audioSource.isPlaying)
        {
            //audioSource.enabled = false;
            audioSource.Pause();
        }     
        else if (!audioSource.isPlaying)
        {
            //audioSource.enabled = true;        
            audioSource.UnPause();
        }
    }
}
