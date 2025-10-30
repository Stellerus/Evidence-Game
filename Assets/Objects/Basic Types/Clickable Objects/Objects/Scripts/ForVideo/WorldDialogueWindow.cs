using UnityEngine;
using TMPro;
using System.Collections;

public class WorldDialogueWindow : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private float typeSlow = 0.02f;
    [SerializeField] private float fadeSpeed = 2f;

    private string[] lines;
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
                textMesh.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue(string[] newLines)
    {
        lines = newLines;
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
        Color c1 = bgColor; c1.a = 0;
        Color c2 = textColor; c2.a = 0;
        background.color = c1;
        textMesh.color = c2;
        textMesh.text = "";
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
            textMesh.ForceMeshUpdate();
            yield return null;
        }

        if (!show)
            HideInstant();
    }

    private void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        textMesh.text = "";
        foreach (char c in lines[index])
        {
            textMesh.text += c;
            yield return new WaitForSeconds(typeSlow);
        }
        isTyping = false;
    }

    private void NextLine()
    {
        index++;
        if (index < lines.Length)
            ShowLine();
        else
            Hide();
    }
}
