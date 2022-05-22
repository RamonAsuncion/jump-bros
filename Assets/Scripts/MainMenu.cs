using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour 
{
    /// <summary>
    /// Load in the first scene.
    /// </summary>
    public void PlayTheGame() 
    {
        SceneManager.LoadScene("Level01");
    }

    /// <summary>
    /// Open up the options menu.
    /// </summary>
    public void OptionButton() 
    {
        SceneManager.LoadScene("Options");
    }
    
    /// <summary>
    /// Quit the game.
    /// </summary>
    public void QuitGame() 
    {
        Application.Quit();
    }
}
