using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static WorldDialogueTrigger;
using UnityEngine.Events;

public class WorldDialogueWindow : MonoBehaviour
{
    public UnityEvent DialogueEndedEvent;

    [Header("Компоненты интерфейса")]
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private SpriteRenderer characterRenderer;

    [Header("Настройки анимации")]
    [SerializeField] private float typeSpeed = 0.02f;
    [SerializeField] private float fadeSpeed = 2f;

    [Header("Звук")]
    [SerializeField] private AudioSource audioSource;

    [Header("Ссылка на триггер")]
    [SerializeField] private WorldDialogueTrigger trigger;

    private List<CharacterLine> characterList;
    private int index;
    private bool isTyping;
    private bool isActive;
    private Coroutine typingCoroutine;
    private Color bgColor;
    private Color textColor;

    // 🔹 новое событие
    public event System.Action OnDialogueEnded;

    private void Start()
    {
        bgColor = background.color;
        textColor = textMesh.color;
        HideInstant();
        bgColor.a = 1;
        textColor.a = 1;
    }

    private void Update()
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
        trigger?.TriggerOff();
        OnDialogueEnded?.Invoke(); // 🔹 уведомляем триггер о завершении
    }

    private void HideInstant()
    {
        Color b = bgColor; b.a = 0;
        Color t = textColor; t.a = 0;
        background.color = b;
        textMesh.color = t;
        textMesh.text = "";
        if (characterRenderer != null)
        {
            characterRenderer.sprite = null;
            characterRenderer.color = new Color(1, 1, 1, 0);
        }
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

        DialogueEndedEvent.Invoke();

        if (!show)
            HideInstant();
    }

    private void ShowLine()
    {
        if (index < 0 || index >= characterList.Count) return;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
/*
        if (trigger.Name != null)
            trigger.Name.text = characterList[index].characterName;*/
        


        var sprite = characterList[index].character;
        if (characterRenderer != null)
        {
            characterRenderer.sprite = sprite;
            characterRenderer.color = sprite ? Color.white : new Color(1, 1, 1, 0);
        }

        PlayVoice(characterList[index]);
        typingCoroutine = StartCoroutine(TypeLine(characterList[index].lines));
        StartCoroutine(HandleDialogueEvent(characterList[index].eventType));
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
            Hide(); // 🔹 завершает диалог и вызывает OnDialogueEnded
    }

    private void PlayVoice(CharacterLine line)
    {
        if (audioSource == null) return;

        audioSource.Stop();

        if (line.voiceClip != null)
        {
            audioSource.clip = line.voiceClip;
            audioSource.Play();
        }
    }

    private IEnumerator FadeInvisibleRoutine(float duration = 1f)
    {
        // Исчезновение
        for (float t = 0; t <= 1; t += Time.deltaTime / duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, t);

            if (background) background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);
            if (textMesh) textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            if (characterRenderer) characterRenderer.color = new Color(characterRenderer.color.r, characterRenderer.color.g, characterRenderer.color.b, alpha);

            yield return null;
        }

        // Смена реплики после исчезновения
        index++;  // переключаемся на следующую строчку
        if (index < characterList.Count)
        {
            ShowLine(); // сразу подготавливаем новую линию, но пока не отображаем
        }
        else
        {
            Hide(); // если реплик больше нет, закрываем диалог
            yield break;
        }

        // Пауза
        yield return new WaitForSeconds(0.1f);

        // Появление
        for (float t = 0; t <= 1; t += Time.deltaTime / duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, t);

            if (background) background.color = new Color(background.color.r, background.color.g, background.color.b, alpha);
            if (textMesh) textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            if (characterRenderer) characterRenderer.color = new Color(characterRenderer.color.r, characterRenderer.color.g, characterRenderer.color.b, alpha);

            yield return null;
        }
    }


    private IEnumerator HandleDialogueEvent(DialogueEvent evt)
    {
        if (evt == DialogueEvent.None)
            yield break;

        if (evt == DialogueEvent.FadeOut && FadeTransition.Instance != null)
            yield return FadeTransition.Instance.FadeOutRoutine(null, false, 1f);

/*        if (evt == DialogueEvent.Invisible && FadeTransition.Instance != null)
            yield return FadeTransition.Instance.FadeInvisibleRoutine(background, textMesh, characterRenderer, 1f);*/

        if (evt == DialogueEvent.Invisible)
            yield return StartCoroutine(FadeInvisibleRoutine(1f));

    }



    public void NextLinePublic()
    {
        if (isActive && !isTyping)
            NextLine();
    }

    public void StopDialoguePublic()
    {
        StopAllCoroutines();
        Hide();
    }
}
