using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteMainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private Toggle _toggleButton;
    
    /**
     * Get the toggle button and enable the music as default.
     */
    private void Start()
    {
        _toggleButton = GetComponent<Toggle>();
        if (AudioListener.volume == 0) 
            _toggleButton.enabled = false;
    }

    /**
     * Pause/Play the audio in the main screen
     */
    public void PressMuteButton(bool audioOn) 
    {
        AudioListener.volume = audioOn ? 1 : 0;
    }
}
