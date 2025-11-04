using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    public static FadeTransition Instance;
    private SpriteRenderer fadeRenderer;
    private Color fadeColor;

    void Awake()
    {
        fadeRenderer = GetComponent<SpriteRenderer>();

        if (fadeRenderer.enabled == false)
        {
            fadeRenderer.enabled = true;
        }

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

        fadeColor = fadeRenderer.color;
        fadeColor.a = 1;
        fadeRenderer.color = fadeColor;
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn(float duration = 1f)
    {
        for (float t = 1; t >= 0; t -= Time.deltaTime / duration)
        {
            fadeColor.a = t;
            fadeRenderer.color = fadeColor;
            yield return null;
        }
    }

    public IEnumerator FadeOut(string nextScene, float duration = 1f)
    {
        for (float t = 0; t <= 1; t += Time.deltaTime / duration)
        {
            fadeColor.a = t;
            fadeRenderer.color = fadeColor;
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
