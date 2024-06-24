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


    public void menuLoadGame() {

        if(loadGameList.activeInHierarchy == true) loadGameList.SetActive(false);
        else{
            loadGameList.SetActive(true);
            optionsList.SetActive(false);
        }
    }

    public void menuOptions() {

        if(optionsList.activeInHierarchy == true) optionsList.SetActive(false);
        else{
            optionsList.SetActive(true);
            loadGameList.SetActive(false);
        }
    }

    public void exitGame() {
        Application.Quit();
    }
}

