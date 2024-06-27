using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.Burst.Intrinsics;
using System.Linq;
using System;

public class UIFirstL : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_InputField login;
    public TMP_InputField password;

    public void Button()
    {
        string path = @"c:\Unlock\PhrasesFirstL.txt";
        string[] array = File.ReadAllLines(path);

        if (login.text == "test" && password.text == "12345") {
            output.text = array[0];
        }
        else if(login.text == "user" && password.text == "user")
        {
            output.text = array[1];
        }
        else if (login.text == "guest" && password.text == "passwOrd")
        {
            output.text = array[2];
        }
        else if (login.text == "admin" && password.text == "admin")
        {
            output.text = array[3] + "\n" + array[4] + "\n" + array[5];
        }
        else if (isPasswordCorrect(password.text))
        {
            output.text = array[7];
        }
        else
        {
            output.text = array[6];
        }
        
    }
    public bool isPasswordCorrect(string pas)
    {
        if (pas.Length >= 8 && pas.Length <= 20)
        {
            Dictionary<string, char> types = new Dictionary<string, char>();
            for (int i = 0; i < pas.Length; i++)
            {
                char c = pas[i];
                if (Char.IsDigit(c)) { types.Add("digit", c); }
                else if (Char.IsLower(c)) { types.Add("lower", c); }
                else if (Char.IsUpper(c)) { types.Add("upper", c); }
                else if (isChar(c)) { types.Add("chars", c); }
            }
            if (types.ContainsKey("digit") && types.ContainsKey("lower") && types.ContainsKey("upper") && types.ContainsKey("chars"))
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
    public bool isChar(char ch)
    {
        if ((ch >= 33 && ch <= 47) || (ch >= 58 && ch <= 64) || (ch >= 91 && ch <= 96) || (ch >= 123 && ch <= 126)) { return true; }
        else { return false; }
    }
}
