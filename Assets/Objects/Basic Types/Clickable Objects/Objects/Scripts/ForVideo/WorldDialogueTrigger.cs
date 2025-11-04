using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [SerializeField] private WorldDialogueWindow dialogueWindow;

    [TextArea(2, 5)]
    [SerializeField] private string[] lines;

    [SerializeField] public List<CharacterLine> CharacterList;

    [Serializable]
    public class CharacterLine
    {
        [TextArea(2, 4)]
        public string lines;
        public Sprite character;
        public AudioClip voiceClip;
    }

    private void OnMouseDown()
    {
        dialogueWindow.StartDialogue(CharacterList);
    }
}