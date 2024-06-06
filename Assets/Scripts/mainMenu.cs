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
    public GameObject newGameList;
    public GameObject loadGameList;
    public GameObject optionsList;

/*
Создаю метод "menuNewGame, в котором производится проверка: является ли newGameList активным (то есть список полей для сохранения игры).
Если является, то он закрывается, а если нет, то он открывается, а остальные закрываются. Аналогично и с остальными методами.
*/
    public void menuNewGame() {

        if(newGameList.activeInHierarchy == true) newGameList.SetActive(false);
        else{
            newGameList.SetActive(true);
            loadGameList.SetActive(false);
            optionsList.SetActive(false);
        }
    }

    public void menuLoadGame() {

        if(loadGameList.activeInHierarchy == true) loadGameList.SetActive(false);
        else{
            loadGameList.SetActive(true);
            newGameList.SetActive(false);
            optionsList.SetActive(false);
        }
    }

    public void menuOptions() {

        if(optionsList.activeInHierarchy == true) optionsList.SetActive(false);
        else{
            optionsList.SetActive(true);
            newGameList.SetActive(false);
            loadGameList.SetActive(false);
        }
    }

    public void exitGame() {
        Application.Quit();
    }
}

