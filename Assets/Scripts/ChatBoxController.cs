using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public DialogueSwitchS dialogueManager; // Link to your dialogue logic script

    // Triggered when clicking on the object
    public void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            dialogueManager.NextDialogue();
        }
    }
}
