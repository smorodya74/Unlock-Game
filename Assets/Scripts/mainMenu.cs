using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadGameList;
    public GameObject optionsList;
    public GameObject soundSettings;
    public GameObject videoSettings;

    public void MenuLoadGame()
    {
        ToggleGameObject(loadGameList);
        if (loadGameList.activeInHierarchy) optionsList.SetActive(false);
    }

    public void MenuOptions()
    {
        ToggleGameObject(optionsList);
        if (optionsList.activeInHierarchy)
        {
            soundSettings.SetActive(true);
            videoSettings.SetActive(false);
            loadGameList.SetActive(false);
        }
        else
        {
            soundSettings.SetActive(false);
            videoSettings.SetActive(false);
        }
    }

    public void MenuSound()
    {
        if (soundSettings.activeInHierarchy == true) { }
        else
        {
            videoSettings.SetActive(false);
            soundSettings.SetActive(true);
        }
    }

    public void MenuVideo()
    {
        if (videoSettings.activeInHierarchy == true) { }
        else
        {
            soundSettings.SetActive(false);
            videoSettings.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ToggleGameObject(GameObject obj)
    {
        obj.SetActive(!obj.activeInHierarchy);
    }
}