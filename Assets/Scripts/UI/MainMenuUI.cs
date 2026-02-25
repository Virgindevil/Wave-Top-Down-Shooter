using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private int _newGameSceneIndex = 1;

    public void StartNewGame()
    {
        SceneManager.LoadScene(_newGameSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
