using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class music : MonoBehaviour
{
    private  AudioSource clip;
    public  Slider slider;
    
    private void Awake()
    {
        clip = GetComponent<AudioSource>();
       
    }
    public void changesize()
    {
       
       clip.volume = slider.value;
       
    }
   
}
