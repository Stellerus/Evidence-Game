using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [SerializeField] private WorldDialogueWindow dialogueWindow;

    [SerializeField] public List<CharacterLine> CharacterList;

    [Serializable]
    public class CharacterLine
    {
        [TextArea(2, 4)]
        public string lines;
        public Sprite character;
        public AudioClip voiceClip;
        public DialogueEvent eventType;
    }

    private void OnMouseDown()
    {
        dialogueWindow.StartDialogue(CharacterList);
    }
}

public enum DialogueEvent
{
    None,
    FadeOut
}
