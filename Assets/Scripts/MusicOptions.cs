using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOptions : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource backgroundMusic;

    public void Update()
    {  
        backgroundMusic.volume = volumeSlider.value;
    }
}
