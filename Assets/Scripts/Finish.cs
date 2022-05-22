using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    /** How many players finished. */
    [HideInInspector]
    public static int _playersFinished; 

    /** Text showing how many people finished. */
    [SerializeField]
    private Text txt;

    /// <summary>
    /// Assign the components for the text.
    /// </summary>
    private void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        txt.text = _playersFinished + "/2 Players finished.";
        if (_playersFinished != 2) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _playersFinished = 0;
    }

   /// <summary>
   /// Player reached the exit.
   /// </summary>
   /// <param name="collision">The exit door.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playersFinished++;
    }
   
    /// <summary>
    /// Player stepped out of the exit.
    /// </summary>
    /// <param name="collision">The exit door.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _playersFinished -= 1;
    }
}
