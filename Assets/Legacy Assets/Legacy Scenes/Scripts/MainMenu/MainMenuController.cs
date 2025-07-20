using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Этот метод вызывается при нажатии на кнопку Exit
    public void ExitGame()
    {
        Debug.Log("Выход из игры...");

        // Если игра запущена в редакторе Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если игра запущена как standalone приложение
        Application.Quit();
#endif
    }
}
