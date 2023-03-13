using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SliderPrefMusic : MonoBehaviour
{
    public Slider slider;

    public float sliderValue;

    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("saveMusic", sliderValue);
    }

    public void changeSliderMusic(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("saveMusic", sliderValue);
    }
}
