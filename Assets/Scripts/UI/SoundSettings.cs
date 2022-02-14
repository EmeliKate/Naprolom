using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider slider;
    public AudioSource music;

    public void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 1;
    }

    public void Update()
    {
        music.volume = slider.value;
    }
}
