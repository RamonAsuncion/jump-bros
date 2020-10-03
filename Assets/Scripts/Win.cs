using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Text txt;
    public int playersCounter = 0;

    public void Start()
    {
        txt = GameObject.FindObjectType<Text>();
    }

    public void update()
    {
        txt.text = playersFinished + "/2 Players finished";
        if (playersFinished == 2)
        {
            print("Players finished");
            SceneManager.LoadScene("Main Menu");
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            print(collision);
            if (collision.tag == "Player")
            {
                print("player finished");
                playersFinished += 1;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                print("player left");
                playersFinished -= 1;
            }
        }
    }
}
}


