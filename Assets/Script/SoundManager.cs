using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource ride, onWater, slowdown,push;
    private SkateControl control;
    private void Start()
    {
        control = GetComponent<SkateControl>();
    }
    public void Play(AudioSource src)
    {
        if (src.isPlaying == false)
        {
            src.Play();
        }
    }
    public void PitchBySpeed(AudioSource src)
    {
        if (control.rb.velocity.magnitude <=3)
        {
            src.pitch = 1;
        }
        else
        {
            src.pitch = control.rb.velocity.magnitude / 5;
        }
    }
}