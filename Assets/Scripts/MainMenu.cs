using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Continue() 
    {
        SceneManager.LoadScene("Assembly");
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("Assembly");
    }

    public void ExitGame()
    {
        Debug.Log("Game is exit");
        Application.Quit();
    }
}
