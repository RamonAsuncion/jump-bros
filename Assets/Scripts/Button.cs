using UnityEngine;

public class Button : MonoBehaviour 
{
    /** Is button pressed? */
    public bool pressed;

    /// <summary>
    /// Check if the player pressed the button.
    /// </summary>
    /// <param name="collision">The button. </param>
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
            pressed = true;
    }
    
    /// <summary>
    /// Check if the player exited the button.
    /// </summary>
    /// <param name="collision">The button. </param>
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
            pressed = false;
    }
}
