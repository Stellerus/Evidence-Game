using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WorldDialogueTrigger;

public class WorldDialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private float typeSpeed = 0.02f;
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private AudioSource audioSource;

    private List<CharacterLine> characterList;
    private int index;
    private bool isTyping;
    private bool isActive;
    private Coroutine typingCoroutine;
    private Color bgColor;
    private Color textColor;

    void Start()
    {
        bgColor = background.color;
        textColor = textMesh.color;
        HideInstant();
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                textMesh.text = characterList[index].lines;
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue(List<CharacterLine> newLines)
    {
        characterList = newLines;
        index = 0;
        Show();
        ShowLine();
    }

    private void Show()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(true));
        isActive = true;
    }

    private void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(false));
        isActive = false;
    }

    private void HideInstant()
    {
        Color b = bgColor; b.a = 0;
        Color t = textColor; t.a = 0;
        background.color = b;
        textMesh.color = t;
        textMesh.text = "";
        if (characterRenderer != null)
            characterRenderer.sprite = null;
    }

    private IEnumerator Fade(bool show)
    {
        float targetAlpha = show ? 1f : 0f;
        while (Mathf.Abs(background.color.a - targetAlpha) > 0.01f)
        {
            float step = Time.deltaTime * fadeSpeed;
            float newAlpha = Mathf.MoveTowards(background.color.a, targetAlpha, step);
            Color b = background.color; b.a = newAlpha;
            Color t = textMesh.color; t.a = newAlpha;
            background.color = b;
            textMesh.color = t;
            yield return null;
        }

        if (!show)
            HideInstant();
    }

    private void ShowLine()
    {
        if (index < 0 || index >= characterList.Count) return;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        if (characterRenderer != null)
        {
            var sprite = characterList[index].character;
            characterRenderer.sprite = sprite;
            characterRenderer.color = sprite ? Color.white : new Color(1, 1, 1, 0);
        }

        PlayVoice(characterList[index]);
        typingCoroutine = StartCoroutine(TypeLine(characterList[index].lines));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        textMesh.text = "";

        foreach (char c in line)
        {
            textMesh.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }

    private void NextLine()
    {
        index++;
        if (index < characterList.Count)
            ShowLine();
        else
            Hide();
    }

    private void PlayVoice(CharacterLine line)
    {
        if (audioSource == null) return;

        if (line.voiceClip != null)
        {
            audioSource.Stop();
            audioSource.clip = line.voiceClip;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
