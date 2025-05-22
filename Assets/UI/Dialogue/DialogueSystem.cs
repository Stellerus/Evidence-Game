using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public DialogueData_SO dialogueData;
    private List<string> dialogueList;
    public TextMesh text;
    public int counter { get; private set; } = 0;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        dialogueList = new List<string>();
        foreach (var dial in dialogueData.dialogueSequence)
        {
            dialogueList.Add(dial);
        }
    }

    private string NextDialogue()
    {
        Debug.Log($"Assigning dialogue: {SetTextMesh()}");
        return dialogueData.dialogueSequence[counter++];
    }

    public string SetTextMesh()
    {
        text.text = dialogueList[counter];
        return text.text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Text assigned: {NextDialogue()}");
        }
    }
}
