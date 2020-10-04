using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int playersFinished = 0;

    public Text txt;

    public GameObject txtUpdate;

    private void Start()
    {
        txt = GameObject.FindObjectOfType<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        txt.text = playersFinished + "/2 Players finished";
        if (playersFinished == 2)
        {
            print("all players finished, loading next level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.tag == "Player")
        {
            print("player finished");
            playersFinished += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("player left");
            playersFinished -= 1;
        }
    }
}
