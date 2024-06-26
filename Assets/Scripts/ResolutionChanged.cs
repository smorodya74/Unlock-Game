using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanged : MonoBehaviour
{
    public Dropdown resolution;
    Resolution[] res;
    public Toggle fullScreenCheck;

    public string screenWidth;
    public string screenHeight;
    public bool fullScreen;

    private void Start()
    {
        fullScreen = fullScreenCheck.isOn;
        res = Screen.resolutions.Distinct().ToArray(); // Вывод разрешений экрана
        string[] strRes = new string[res.Length];

        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + 'x' + res[i].height.ToString();
        }

        resolution.ClearOptions();
        resolution.AddOptions(strRes.ToList());

    }

    public void SetRes ()
    {
        Screen.SetResolution(res[resolution.value].width, res[resolution.value].height, fullScreenCheck.isOn);
    }

    private void SaveScreenSetting()
    {
        PlayerPrefs.SetString("screenWidth", res[resolution.value].width.ToString());
        PlayerPrefs.SetString("screenHeight", res[resolution.value].height.ToString());
        PlayerPrefs.SetString("fullScreen", fullScreenCheck.isOn.ToString());
    }
    
    private void LoadScreenSetting()
    {
        if (PlayerPrefs.HasKey("screenWidth"))
        {
            res[resolution.value].width = Convert.ToInt32(PlayerPrefs.GetString("screenWidth"));
        }
        else
        {
            res[resolution.value].width = Screen.currentResolution.width; // Начальное значение ширины экрана
        }

        if (PlayerPrefs.HasKey("screenHeight"))
        {
            res[resolution.value].height = Convert.ToInt32(PlayerPrefs.GetString("screenHeight"));
        }
        else
        {
            res[resolution.value].width = Screen.currentResolution.height; // Начальное значение высоты экрана
        }

        if (PlayerPrefs.HasKey("fullScreen"))
        {
            fullScreen = Convert.ToBoolean(PlayerPrefs.GetString("fullScreen"));
        }
        else
        {
            fullScreen = true; // Начальное значение полноэкранного режима
        }
    }
}
