using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource mainMenuAudioSrc;
    
    void Awake()
    {
        mainMenuAudioSrc = this.GetComponent<AudioSource>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMenuMusic");
        if (objs.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex >= 3)
        {

            mainMenuAudioSrc.mute = true;
        }
        else
        {

            mainMenuAudioSrc.volume = PlayerPrefs.GetInt("MainMenuVolume");
        }
    }

}
