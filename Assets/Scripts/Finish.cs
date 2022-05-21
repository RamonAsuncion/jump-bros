using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// TODO: Add comments to all the code that is not intuitive to understand. (ADD PERIOD)

public class Finish : MonoBehaviour
{
    /** How many players finished. */
    private int _playersFinished;

    /* Text showing how many people finished. */
    [SerializeField]
    private Text txt;
    
    
    /**
     * Assign the components for the text.
     */
    private void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    /*
     * Update is called once per frame
     */
    public void Update()
    {
        txt.text = _playersFinished + "/2 Players finished";
        if (_playersFinished != 2) return;
        Debug.Log("All players finished! Loading next level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Player reached the exit. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playersFinished++;
    }

    // Player stepped out of the exit.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playersFinished -= 1;
    }
}
