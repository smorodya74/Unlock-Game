using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFirstL : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_InputField login;
    public TMP_InputField password;
    public void Button()
    {
        if (login.text == "admin" && password.text == "admin") {
            output.text = "�������� ������ ������� ������������ ������ ����� ������ ... �������� � ��������..." +
        "\r\n��� ������ ������. ����� � ������ ������ ����� ������� ���������, ����� ������� ���� ������ ���������. " +
        "����� � ������ ����������� ���� ���������� ������� � �������, ������� �������� �� ������������ ��������." +
        " �������� ������ ����� ��� + ���� �������� + ��� ������� �� ������. \r\n"; ;
        }
        else if(login.text == "test" && password.text == "12345")
        {
            output.text = "� ��� ������� ��� �������� ������������� " +
                "�� ���� �������� ������������� ����� �������, ���� ������� ������� ������, ����� �������� ������ ������ ����������.";
        }
        else
        {
            output.text = "���... ���-�� �� ��.\r\n" +
                "�������� ��������������� ��������� �� ������.";
        }
    }
}
