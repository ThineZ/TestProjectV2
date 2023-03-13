using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderPrefSFX : MonoBehaviour
{
    public Slider slider;

    public float sliderValue;

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("saveSFX", sliderValue);
    }

    public void changeSliderSFX(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("saveSFX", sliderValue);
    }
}
