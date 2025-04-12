using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame() 
    {
        SceneManager.LoadScene("");
    }

    public void LoadGame()
    {

    }

    public void ExitGame()
    {
        Debug.Log("Game is exit");
        Application.Quit();
    }
}
