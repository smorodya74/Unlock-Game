using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    public GameObject loadGameList;
    public GameObject optionsList;
    public GameObject soundSettigs;
    public GameObject videoSettings;


    public void menuLoadGame() 
    {

        if(loadGameList.activeInHierarchy == true) loadGameList.SetActive(false);
        else{
            loadGameList.SetActive(true);
            optionsList.SetActive(false);
        }
    }

    public void menuOptions()
    {
        if (optionsList.activeInHierarchy == true)
        {
            soundSettigs.SetActive(false);
            videoSettings.SetActive(false);
            optionsList.SetActive(false);
        }
        else
        {
            optionsList.SetActive(true);
            soundSettigs.SetActive(true);
            loadGameList.SetActive(false);
        }
    }

    public void menuSound()
    {
        if (soundSettigs.activeInHierarchy == true) { }
        else
        {
            videoSettings.SetActive(false);
            soundSettigs.SetActive(true);
        }
    }

    public void menuVideo()
    {
        if (videoSettings.activeInHierarchy == true) { }
        else
        {
            soundSettigs.SetActive(false);
            videoSettings.SetActive(true);
        }
    }

    public void exitGame() 
    {
        Application.Quit();
    }
}

