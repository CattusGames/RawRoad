using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private AudioSource buttonClickSrc;
    public AudioClip buttonClick;

    float beforeMuteVolume;
    float otherVolume;

    public Sprite muted;
    public Sprite unMuted;

    private void Start()
    {
        beforeMuteVolume = PlayerPrefs.GetFloat("MainMenuVolume");

        buttonClickSrc = gameObject.GetComponent<AudioSource>();
    }
    public void LoadLevel(int numLvl)
    {
        otherVolume = PlayerPrefs.GetFloat("OtherVolume");
        buttonClickSrc.PlayOneShot(buttonClick, otherVolume);
        SceneManager.LoadScene(numLvl);
    }

    public void ClickOnGUI(GameObject nextParent)
    {
        otherVolume = PlayerPrefs.GetFloat("OtherVolume");
        buttonClickSrc.PlayOneShot(buttonClick, otherVolume);
        GameObject parent = GameObject.FindWithTag("UIParent");
        parent.SetActive(false);
        nextParent.SetActive(true);
    }

    public void Mute()
    {
        
        GameObject obj = GameObject.FindGameObjectWithTag("MainMenuMusic");
        AudioSource src = obj.GetComponent<AudioSource>();
        if (src.volume > 0)
        {
             PlayerPrefs.SetFloat("MainMenuVolume",0);
            
        }
        else
        {
            PlayerPrefs.SetFloat("MainMenuVolume", beforeMuteVolume);
        }
    }

}
