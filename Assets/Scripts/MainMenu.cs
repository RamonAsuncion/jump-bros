using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public void PlayTheGame() {
        SceneManager.LoadScene("Level01");
    }

    public void OptionButton() {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
