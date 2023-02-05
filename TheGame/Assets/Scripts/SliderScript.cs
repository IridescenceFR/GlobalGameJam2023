using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public WaveScript wave;
    private float waveX = 0;
    

    void Start()
    {
        waveX = wave.transform.position.x;

    }
    void FixedUpdate()
    {
        float newX = wave.transform.position.x;
        slider.value = 1 - (newX / waveX);
    }
	
}