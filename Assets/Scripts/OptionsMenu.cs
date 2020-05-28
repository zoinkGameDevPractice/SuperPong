using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public void MusicVolume(float volume)
    {
        mixer.SetFloat("mVolume", volume);
    }

    public void SFXVolume(float volume)
    {
        mixer.SetFloat("sVolume", volume);
    }
}
