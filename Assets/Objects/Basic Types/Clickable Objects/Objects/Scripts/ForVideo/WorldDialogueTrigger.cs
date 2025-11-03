using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [SerializeField] private WorldDialogueWindow dialogueWindow;

    [TextArea(2, 5)]
    [SerializeField] private string[] lines;

    [SerializeField] private List<CharacterLine> CharacterList;

    [Serializable]
    public class CharacterLine
    {
        public string lines;
        public Sprite character;
    }

    private void OnMouseDown()
    {
        dialogueWindow.StartDialogue(lines);
    }
}