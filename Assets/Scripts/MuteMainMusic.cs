using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MuteMainMusic : MonoBehaviour
{
    private bool muteMusic;
    [SerializeField] Toggle audioToggle;

    void Start()
    {
        muteMusic = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = muteMusic;
    }

    public void pressMuteButton()
    {
        muteMusic = !muteMusic;
        AudioListener.pause = muteMusic;
        PlayerPrefs.SetInt("MUTED", muteMusic ? 1 : 0);
    }
}
