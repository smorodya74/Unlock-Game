using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource mainMenuMusic;
    public AudioSource levelMusic;
    public AudioSource sfxSource;

    private float musicVolume = 0.3f;
    private float sfxVolume = 0.3f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadVolumes();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        UpdateMusicVolume();
        SaveVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        if (sfxSource != null) sfxSource.volume = sfxVolume;
        SaveVolumes();
    }

    public float GetMusicVolume()
        => musicVolume;

    public float GetSFXVolume()
        => sfxVolume;

    private void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    private void LoadVolumes()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.3f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.3f);
        UpdateMusicVolume();
        if (sfxSource != null) sfxSource.volume = sfxVolume;
    }

    private void UpdateMusicVolume()
    {
        if (mainMenuMusic != null) mainMenuMusic.volume = musicVolume;
        if (levelMusic != null) levelMusic.volume = musicVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource?.PlayOneShot(clip, sfxVolume);
    }
}