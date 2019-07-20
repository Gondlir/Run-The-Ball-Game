using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public AudioSource audioBackground;
    public Image imgOn;
    public Image imgOff;

    public void Stop()
    {
        if (audioBackground.isPlaying)
        {
            audioBackground.Pause();
            imgOn.enabled = false;
            imgOff.enabled = true;
            
        }
        else
        {
            audioBackground.Play();
            imgOn.enabled = true;
            imgOff.enabled = false;
        }      
    }

    
}
