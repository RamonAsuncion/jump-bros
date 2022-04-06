using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {
    /** How many players finished */
    public int playersFinished;

    /* Text showing how many people finished */
    public Text txt;
    
    private void Start() {
        txt = FindObjectOfType<Text>();
    }
    // Update is called once per frame
    public void Update() {
        // TODO: Add text box and add this object below to it.
        // txt.text = playersFinished + "/2 Players finished";
        if (playersFinished != 2) return;
        Debug.Log("All players finished! Loading next level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            // Debug.Log("Player finished!");
            playersFinished += 1;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            // Debug.Log("Player left!");
            playersFinished -= 1;
        }
    }
}
