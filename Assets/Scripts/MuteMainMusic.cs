using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private bool muteMusic;

    void Start()
    {
        muteMusic = false;
    }

    // Update is called once per frame
    public void pressMuteButton()
    {
        muteMusic = !muteMusic;
        AudioListener.pause = muteMusic;
    }
}
