using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    public void PlaySound()
    {
        if (buttonClickSound != null)
        {
            AudioManager.instance.PlaySFX(buttonClickSound);
        }
        else
        {
            Debug.LogError("Button click sound is not set!");
        }
    }
}

