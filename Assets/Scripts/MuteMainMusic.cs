using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteMainMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private Toggle _toggleButton;

    private void Start() {
        _toggleButton = GetComponent<Toggle>();
        if (AudioListener.volume == 0) {
            _toggleButton.isOn = false;
        }
    }

    public void PressMuteButton(bool audioOn) {
        AudioListener.volume = audioOn ? 1 : 0;
    }
}
