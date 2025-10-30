using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [SerializeField] private WorldDialogueWindow dialogueWindow;

    [TextArea(2, 5)]
    [SerializeField] private string[] lines;

    private void OnMouseDown()
    {
        dialogueWindow.StartDialogue(lines);
    }
}