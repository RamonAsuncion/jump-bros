using UnityEngine;

public class Button : MonoBehaviour 
{
    /** Check if the button is pressed. */
    public bool pressed;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
            pressed = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
            pressed = false;
    }
}
