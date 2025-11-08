using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WorldDialogueTrigger : MonoBehaviour
{
    [Header("Настройки диалога")]
    [SerializeField] private WorldDialogueWindow dialogueWindow;
    [SerializeField] public List<CharacterLine> characterList;
/*    [SerializeField] public String characterName = string.Empty;
    [SerializeField] public TextMeshPro Name;*/
    [SerializeField] public bool DialogueEnded = false;
    private BoxCollider2D boxCollider;
    private bool dialogueActive = false; // 🔹 флаг, чтобы не перезапускать

    [Serializable]
    public class CharacterLine
    {
        [TextArea(2, 4)] public string lines;
        public Sprite character;
        public AudioClip voiceClip;
        public DialogueEvent eventType;
/*        public String characterName;*/
    }

    public enum DialogueEvent
    {
        None,
        FadeOut,
        Invisible
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        // 🔹 Если диалог уже идёт или завершён — игнорируем
        if (dialogueActive || DialogueEnded)
            return;
        

        StartDialogue();
    }

    public void Initialize()
    {
        DialogueEnded = false;
        dialogueActive = false;
        if (boxCollider != null)
            boxCollider.enabled = true;
    }

    public void StartDialogue()
    {
        if (dialogueWindow != null)
        {
            dialogueActive = true;
            dialogueWindow.StartDialogue(characterList);
        }
    }

    private void OnDialogueFinished()
    {
        dialogueActive = false;
        DialogueEnded = true;
        TriggerOff();
    }

    public void NextLine()
    {
        dialogueWindow?.NextLinePublic();
    }

    public void StopDialogue()
    {
        dialogueWindow?.StopDialoguePublic();
        dialogueActive = false;
    }

    public void TriggerOff()
    {
        if (boxCollider != null)
            boxCollider.enabled = false;
    }

}
