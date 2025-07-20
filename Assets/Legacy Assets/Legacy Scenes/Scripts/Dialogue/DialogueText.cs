using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    [SerializeField]
    List<string> Text = new List<string>();

    GameObject textMesh;

    private void Reset()
    {
        textMesh = transform.GetChild(0).gameObject;
        textMesh.GetComponent<TextMesh>().text = Text[0];
    }

    private void Awake()
    {
        textMesh = transform.GetChild(0).gameObject;
        textMesh.GetComponent<TextMesh>().text = Text[0];
    }
}
