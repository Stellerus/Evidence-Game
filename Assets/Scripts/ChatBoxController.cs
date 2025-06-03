using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public DialogueSwitchS dialogueManager; // Ссылка на ваш скрипт с логикой диалогов

    // Вызывается при клике на объект
    public void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            dialogueManager.NextDialogue();
        }
    }
}
