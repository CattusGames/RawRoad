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

    RectTransform img;

    // Update is called once per frame
    private void Awake()
    {

        
        buttonClickSrc = gameObject.GetComponent<AudioSource>();

        img = gameObject.GetComponent<RectTransform>();



    }

    private void Update()
    {
        if (soundVolumeSlider)
        {
            var e = PlayerPrefs.GetInt("OtherVolume");
            CheckPivot(e);
        }
        if (musicVolumeSlider)
        {
            var e = PlayerPrefs.GetInt("MainMenuVolume");
            CheckPivot(e);
        }
        
       
  
    }

    public void SoundOn()
    {
        var e = PlayerPrefs.GetInt("OtherVolume");
        if (e >= 0.9)
        {
            img.pivot = new Vector2(0, 0.5f);
            PlayerPrefs.SetInt("OtherVolume", 0);

        }
        else if (e <= 0.1)
        {
            img.pivot = new Vector2(1, 0.5f);
            PlayerPrefs.SetInt("OtherVolume", 1);
            buttonClickSrc.PlayOneShot(buttonClick, 1);

        }


    }


    public void MusicOn()
    {
        var e = PlayerPrefs.GetInt("MainMenuVolume");
        if (e >= 0.9)
        {
            img.pivot = new Vector2(0, 0.5f);
            PlayerPrefs.SetInt("MainMenuVolume", 0);
        }
        else if (e <= 0.1)
        {
            img.pivot = new Vector2(1, 0.5f);
            PlayerPrefs.SetInt("MainMenuVolume", 1);
            buttonClickSrc.PlayOneShot(buttonClick, 1);
        }
    }

    public void CheckPivot(float e)
    {
        
        if (e >= 0.9)
        {
            img.pivot = new Vector2(1, 0.5f);
        }
        else if (e <= 0.1)
        {
            img.pivot = new Vector2(0, 0.5f);
        }
    }
}
