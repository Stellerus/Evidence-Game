using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public DialogueSwitchS dialogueManager; // Link to your dialogue logic script
    public RingingDialogueSwitch ringingDialogueSwitch;
    public Court Court; // Link to the Court script
    // Triggered when clicking on the object
    public void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            dialogueManager.NextDialogue();
        }
        if (ringingDialogueSwitch != null)
        {
            ringingDialogueSwitch.NextDialogue();
        }
        if (Court != null)
        {
            Court.NextDialogue();
        }
    }
}
