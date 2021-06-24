using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    public void MainMenuButton()
    { 
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgainButton()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Debug.Log("Quit Button");
        Application.Quit();
    }
}
