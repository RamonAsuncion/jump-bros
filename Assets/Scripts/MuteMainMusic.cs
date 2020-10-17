using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteMainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    Toggle toggleButton;

    void Start()
    {
        toggleButton = GetComponent<Toggle>();
        if (AudioListener.volume == 0)
        {
            toggleButton.isOn = false;
        }
    }

    public void pressMuteButton(bool audio)
    {
        if (audio)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
}
