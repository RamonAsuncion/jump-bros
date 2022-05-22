using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteMainMusic : MonoBehaviour
{
    /** Start is called before the first frame update. */
    private Toggle _toggleButton;
    
    /// <summary>
    /// Get the toggle button and enable the music as default.
    /// </summary>
    private void Start()
    {
        _toggleButton = GetComponent<Toggle>();
        if (AudioListener.volume == 0) 
            _toggleButton.enabled = false;
    }

    /// <summary>
    /// Pause/Play the audio in the main screen.
    /// </summary>
    /// <param name="audioOn">True/False is the audio on?</param>
    public void PressMuteButton(bool audioOn) 
    {
        AudioListener.volume = audioOn ? 1 : 0;
    }
}
