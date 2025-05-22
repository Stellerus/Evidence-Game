using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Continue() 
    {
        SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        Debug.Log("Game is exit");
        Application.Quit();
    }
}
