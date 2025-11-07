using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition Instance;

    [Header("2D Fade")]
    [SerializeField] private SpriteRenderer fadeRenderer;
    private Color fadeColor;

    [Header("UI Fade (Canvas)")]
    [SerializeField] private Image fadeUIImage;
    private Color uiFadeColor;

    [SerializeField] public string nextScene;
    [SerializeField] private bool MoveToNextScene;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (fadeRenderer)
        {
            fadeRenderer.enabled = true;
            fadeColor = fadeRenderer.color;
            fadeColor.a = 1;
            fadeRenderer.color = fadeColor;
        }

        if (fadeUIImage)
        {
            fadeUIImage.enabled = true;
            uiFadeColor = fadeUIImage.color;
            uiFadeColor.a = 1;
            fadeUIImage.color = uiFadeColor;
        }

        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn(float duration = 1f)
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime / duration)
        {
            if (fadeRenderer)
            {
                fadeColor.a = t;
                fadeRenderer.color = fadeColor;
            }
            if (fadeUIImage)
            {
                uiFadeColor.a = t;
                fadeUIImage.color = uiFadeColor;
            }
            yield return null;
        }
    }

    public IEnumerator FadeInvisibleRoutine(SpriteRenderer background, TextMeshPro textMesh, SpriteRenderer characterRenderer, float duration = 1f)
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

        // Пауза перед возвращением
        yield return new WaitForSeconds(0.3f);

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


    public IEnumerator FadeOutRoutine(string nextScene, bool loadScene = false, float duration = 1f)
    {
        for (float t = 0; t <= 1; t += Time.deltaTime / duration)
        {
            if (fadeRenderer)
            {
                fadeColor.a = t;
                fadeRenderer.color = fadeColor;
            }
            if (fadeUIImage)
            {
                uiFadeColor.a = t;
                fadeUIImage.color = uiFadeColor;
            }
            yield return null;
        }

        if (loadScene && !string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            yield return new WaitForSeconds(0.3f);
            yield return StartCoroutine(FadeIn(duration));
        }
    }
}
