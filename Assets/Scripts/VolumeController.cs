using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        if (AudioManager.instance == null) return;

        musicVolumeSlider.value = AudioManager.instance.GetMusicVolume();
        sfxVolumeSlider.value = AudioManager.instance.GetSFXVolume();

        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSFXVolumeChange(); });
    }

    public void OnMusicVolumeChange()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.SetMusicVolume(musicVolumeSlider.value);
    }

    public void OnSFXVolumeChange()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.SetSFXVolume(sfxVolumeSlider.value);
    }
}