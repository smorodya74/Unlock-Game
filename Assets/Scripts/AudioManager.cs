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
        if (mainMenuMusic != null) mainMenuMusic.volume = musicVolume;
        if (levelMusic != null) levelMusic.volume = musicVolume;
        SaveVolumes();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        if (sfxSource != null) sfxSource.volume = sfxVolume;
        SaveVolumes();
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    private void SaveVolumes()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    private void LoadVolumes()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicVolume = 0.3f; // Начальное значение громкости музыки по умолчанию
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            sfxVolume = 0.3f; // Начальное значение громкости звуков по умолчанию
        }

        if (mainMenuMusic != null) mainMenuMusic.volume = musicVolume;
        if (levelMusic != null) levelMusic.volume = musicVolume;
        if (sfxSource != null) sfxSource.volume = sfxVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume);
    }
}
