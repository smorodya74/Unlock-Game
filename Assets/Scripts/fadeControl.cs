using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeControl : MonoBehaviour
{
    public GameObject FadeOut;

    public void fadeOff()
    {
        FadeOut.SetActive(false);
    }
}
