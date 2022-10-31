using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    private AudioSource buttonClickSrc;
    public AudioClip buttonClick;
    float otherVolume;

    private void Start()
    {
        otherVolume = PlayerPrefs.GetInt("OtherVolume");
        buttonClickSrc = gameObject.GetComponent<AudioSource>();

    }
    public void LoadLevel(int numLvl)
    {
        
        buttonClickSrc.PlayOneShot(buttonClick, otherVolume);
        SceneManager.LoadScene(numLvl);
    }

    public void ClickOnGUI(GameObject nextParent)
    {
        buttonClickSrc.PlayOneShot(buttonClick, otherVolume);
        GameObject parent = GameObject.FindWithTag("UIParent");
        parent.SetActive(false);
        nextParent.SetActive(true);
    }
}
