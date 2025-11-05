using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [Header("Настройки диалога")]
    [SerializeField] private WorldDialogueWindow dialogueWindow;
    [SerializeField] private List<CharacterLine> characterList;

    [Serializable]
    public class CharacterLine
    {
        [TextArea(2, 4)]
        public string lines;
        public Sprite character;
        public AudioClip voiceClip;
        public DialogueEvent eventType;
    }

    public enum DialogueEvent
    {
        None,
        FadeOut
    }

    public void StartDialogue()
    {
        dialogueWindow.StartDialogue(characterList);
    }

    public void NextLine()
    {
        if (dialogueWindow != null)
            dialogueWindow.NextLinePublic();
    }

    public void StopDialogue()
    {
        if (dialogueWindow != null)
            dialogueWindow.StopDialoguePublic();
    }

    private void OnMouseDown()
    {
        StartDialogue();
    }
}
