using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{ 
    /// <summary>
    /// Player reached the exit.
    /// </summary>
    /// <param name="collision">The exit door.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Finish._playersFinished++;
    }

    /// <summary>
    /// Player stepped out of the exit.
    /// </summary>
    /// <param name="collision">The exit door.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Finish._playersFinished -= 1;
    }
}
