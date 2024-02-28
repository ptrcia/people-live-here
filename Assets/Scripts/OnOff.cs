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
        Debug.Log("On/Off...");
        //Destroy(gameObject);

        if(audioSource.enabled)
        {
            //audioSource.enabled = false;
            audioSource.Pause();
        }
        
        if (!audioSource.enabled)
        {
            //audioSource.enabled = true;        
            audioSource.Play();
        }
    }
}
