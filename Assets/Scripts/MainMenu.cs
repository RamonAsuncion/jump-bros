using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayTheGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("LevelTutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
