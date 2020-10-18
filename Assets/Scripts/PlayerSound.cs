using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public static AudioClip playerJumpSounds;
    static AudioSource sound;



    // Start is called before the first frame update
    void Start()
    {
        playerJumpSounds = Resources.Load<AudioClip>("jump");
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void checkWhatSoundsToPlay(string clip)
    {
        if (clip == "jump")
        {
            sound.PlayOneShot(playerJumpSounds);
        }
    }
}
