using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicManager : MonoBehaviour
{
    AudioSource _mainMenuAudioSrc;
    [SerializeField] private AudioSource _backgroundMusic, _coinSound, _scoreSound, _deathSound, _buttonClickSound, _skinSwitchSound, _notEnoughTokenSound;

    [HideInInspector]
    public bool _soundIsOn = true;       //GameManager script might modify this value
    [HideInInspector]
    public bool _musicIsOn = true;       //GameManager script might modify this value
    [HideInInspector]
    public bool _vibrationIsOn = true;       //GameManager script might modify this value

    private void Update()
    {

        if (PlayerPrefs.GetInt("MainMenuVolume")==0)
        {

            _mainMenuAudioSrc.mute = true;
        }
    }

    public void StopBackgroundMusic()
    {
        _backgroundMusic.Stop();
    }
    public void PlayVibration()
    {
        Handheld.Vibrate();
    }
    public void PlayBackgroundMusic()
    {
        if (_musicIsOn)
            _backgroundMusic.Play();
    }

    public void CoinSound()
    {
        if (_soundIsOn)
            _coinSound.Play();
    }

    public void ScoreSound()
    {
        if (_soundIsOn)
            _scoreSound.Play();
    }

    public void DeathSound()
    {
        if (_soundIsOn)
            _deathSound.Play();
        if (_vibrationIsOn)
            PlayVibration();
    }

    public void ButtonClickSound()
    {
        if (_soundIsOn)
            _buttonClickSound.Play();
    }

    public void NotEnoughTokenSound()
    {
        if (_soundIsOn)
            _notEnoughTokenSound.Play();
        if (_vibrationIsOn)
            PlayVibration();
    }

    public void SkinSwitchSound()
    {
        if (_soundIsOn)
            _skinSwitchSound.Play();
    }
}
