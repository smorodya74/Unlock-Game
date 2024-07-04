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
        res = res.GroupBy(r => new { r.width, r.height }).Select(g => g.First()).ToList(); // ������� ��������� ����������

        List<string> strRes = new List<string>();
        for (int i = 0; i < res.Count; i++)
        {
            strRes.Add(res[i].width + "x" + res[i].height);
        }

        resolution.ClearOptions();
        resolution.AddOptions(strRes);

        LoadScreenSetting(); // ��������� ��������� ������

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
            Debug.LogError("������: ���� ��� ��������� �������� �� ���������������� ��� ��������� ��� ���������� ��������.");
        }
    }

    private void SaveScreenSetting()
    {
        PlayerPrefs.SetString("screenWidth", res[resolution.value].width.ToString()); // ��������� ������ ������
        PlayerPrefs.SetString("screenHeight", res[resolution.value].height.ToString()); // ��������� ������ ������
        PlayerPrefs.SetString("fullScreen", fullScreenCheck.isOn.ToString()); // ��������� ������������� �����
    }

    private void LoadScreenSetting()
    {
        int width = Screen.currentResolution.width; // �������� �� ���������
        int height = Screen.currentResolution.height; // �������� �� ���������
        bool isFullScreen = true; // �������� �� ���������

        if (PlayerPrefs.HasKey("screenWidth"))
        {
            width = Convert.ToInt32(PlayerPrefs.GetString("screenWidth")); // ��������� ������ ������
        }

        if (PlayerPrefs.HasKey("screenHeight"))
        {
            height = Convert.ToInt32(PlayerPrefs.GetString("screenHeight")); // ��������� ������ ������
        }

        if (PlayerPrefs.HasKey("fullScreen"))
        {
            if (bool.TryParse(PlayerPrefs.GetString("fullScreen"), out isFullScreen))
            {
                FullScreen = isFullScreen;
            }
            else
            {
                FullScreen = true; // �� ��������� ������������� �����
            }
        }

        // ������������� �������� dropdown, ��������������� ������������ ����������
        int resolutionIndex = res.FindIndex(r => r.width == width && r.height == height);
        if (resolutionIndex != -1)
        {
            resolution.value = resolutionIndex;
        }

        Screen.SetResolution(width, height, FullScreen);
    }
}