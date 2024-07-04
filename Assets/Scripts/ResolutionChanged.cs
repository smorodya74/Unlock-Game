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
    public Toggle fullScreenCheck;
    private List<Resolution> res;
    private bool FullScreen;

    private void Start()
    {
        res = Screen.resolutions.ToList();
        res = res.GroupBy(r => new { r.width, r.height }).Select(g => g.First()).ToList(); // Удаляем дубликаты разрешений

        List<string> strRes = new List<string>();
        for (int i = 0; i < res.Count; i++)
        {
            strRes.Add(res[i].width + "x" + res[i].height);
        }

        resolution.ClearOptions();
        resolution.AddOptions(strRes);

        LoadScreenSetting(); // Загружаем настройки экрана

        fullScreenCheck.isOn = FullScreen;
        resolution.RefreshShownValue();
    }

    public void SetRes()
    {

        if (resolution != null && res != null && resolution.value < res.Count && fullScreenCheck != null)
        {
            Screen.SetResolution(res[resolution.value].width, res[resolution.value].height, fullScreenCheck.isOn);
            SaveScreenSetting();
        }
        else
        {
            Debug.LogError("Ошибка: Один или несколько объектов не инициализированы или находятся вне допустимых пределов.");
        }
    }

    private void SaveScreenSetting()
    {
        PlayerPrefs.SetString("screenWidth", res[resolution.value].width.ToString()); // Сохраняем ширину экрана
        PlayerPrefs.SetString("screenHeight", res[resolution.value].height.ToString()); // Сохраняем высоту экрана
        PlayerPrefs.SetString("fullScreen", fullScreenCheck.isOn.ToString()); // Сохраняем полноэкранный режим
    }

    private void LoadScreenSetting()
    {
        int width = Screen.currentResolution.width; // Значение по умолчанию
        int height = Screen.currentResolution.height; // Значение по умолчанию
        bool isFullScreen = true; // Значение по умолчанию

        if (PlayerPrefs.HasKey("screenWidth"))
        {
            width = Convert.ToInt32(PlayerPrefs.GetString("screenWidth")); // Загружаем ширину экрана
        }

        if (PlayerPrefs.HasKey("screenHeight"))
        {
            height = Convert.ToInt32(PlayerPrefs.GetString("screenHeight")); // Загружаем высоту экрана
        }

        if (PlayerPrefs.HasKey("fullScreen"))
        {
            if (bool.TryParse(PlayerPrefs.GetString("fullScreen"), out isFullScreen))
            {
                FullScreen = isFullScreen;
            }
            else
            {
                FullScreen = true; // По умолчанию полноэкранный режим
            }
        }

        // Устанавливаем значение dropdown, соответствующее сохраненному разрешению
        int resolutionIndex = res.FindIndex(r => r.width == width && r.height == height);
        if (resolutionIndex != -1)
        {
            resolution.value = resolutionIndex;
        }

        Screen.SetResolution(width, height, FullScreen);
    }
}