using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{

    public bool soundVolumeSlider;
    public bool musicVolumeSlider;

    private AudioSource buttonClickSrc;
    public AudioClip buttonClick;

    float otherVolume;

    // Update is called once per frame
    private void Awake()
    {
        buttonClickSrc = gameObject.GetComponent<AudioSource>();
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("OtherVolume");
        }
        if (musicVolumeSlider)
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MainMenuVolume");
        }
        
    }
    void Update()
    {
        if (soundVolumeSlider)
        {
            PlayerPrefs.SetFloat("OtherVolume", gameObject.GetComponent<Slider>().value);
            gameObject.GetComponent<Slider>().onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
        if (musicVolumeSlider)
        {
            PlayerPrefs.SetFloat("MainMenuVolume", gameObject.GetComponent<Slider>().value);
        }
    }
    public void ValueChangeCheck()
    {
        otherVolume = PlayerPrefs.GetFloat("OtherVolume");
        buttonClickSrc.PlayOneShot(buttonClick, otherVolume*0.05f);
    }
}
