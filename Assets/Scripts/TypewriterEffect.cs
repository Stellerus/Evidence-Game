using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class Typewriter3DEffect : MonoBehaviour
{
    [SerializeField] private float charsPerSecond = 20;
    [SerializeField] private float punctuationPause = 0.5f;

    private TextMesh textMesh;
    private string fullText;
    private Coroutine typingCoroutine;
    private bool isSkipping;

    void Awake()
    {
        textMesh = GetComponent<TextMesh>();
        fullText = textMesh.text;
        textMesh.text = "";
    }

    public void StartTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeCharacters());
    }

    private IEnumerator TypeCharacters()
    {
        textMesh.text = "";
        int currentChar = 0;

        while (currentChar < fullText.Length)
        {
            if (isSkipping)
            {
                textMesh.text = fullText;
                yield break;
            }

            textMesh.text += fullText[currentChar];

            // pause for punctuation
            if (IsPunctuation(fullText[currentChar]))
                yield return new WaitForSeconds(punctuationPause);
            else
                yield return new WaitForSeconds(1 / charsPerSecond);

            currentChar++;
        }
    }

    public void SkipTyping()
    {
        isSkipping = true;
    }

    private bool IsPunctuation(char c)
    {
        return c == '.' || c == '!' || c == '?' || c == ';' || c == ':';
    }
}

