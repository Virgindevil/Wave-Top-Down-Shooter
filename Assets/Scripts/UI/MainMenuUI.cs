using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
