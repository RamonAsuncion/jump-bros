using UnityEngine;

public class Button : MonoBehaviour 
{
    /** Is button pressed? */
    public bool pressed;

    /*
     * Check if the player pressed the button.
     */
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
            pressed = true;
    }
    
    /*
     * Check if the player exited the button.
     */
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
            pressed = false;
    }
}
