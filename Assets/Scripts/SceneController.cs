using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Инициализация громкости при загрузке первой сцены
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (AudioManager.instance.mainMenuMusic != null)
            {
                AudioManager.instance.mainMenuMusic.volume = AudioManager.instance.GetMusicVolume();
                AudioManager.instance.mainMenuMusic.Play();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            GameObject levelMusicObject = GameObject.Find("LevelMusic");
            if (levelMusicObject != null)
            {
                AudioSource levelMusicSource = levelMusicObject.GetComponent<AudioSource>();
                AudioManager.instance.levelMusic = levelMusicSource;
                AudioManager.instance.SetMusicVolume(AudioManager.instance.GetMusicVolume());
                AudioManager.instance.levelMusic.Play();

                if (AudioManager.instance.mainMenuMusic != null && AudioManager.instance.mainMenuMusic.isPlaying)
                {
                    AudioManager.instance.mainMenuMusic.Stop();
                }
            }
        }
    }
}
