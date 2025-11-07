using System.Collections;
using UnityEngine;

public class ScreenNight : MonoBehaviour
{
    [Header("Insert black image (full black sprite)")]
    [SerializeField] private SpriteRenderer NightMask;

    [Header("Insert mask (gradient sprite: black -> transparent)")]
    [SerializeField] private SpriteRenderer FadeMask;

    [Header("Настройки плавности и паузы")]
    [SerializeField, Min(0.01f)] private float fadeSpeed = 1.0f;
    [SerializeField, Min(0f)] private float waitTime = 2.0f;

    [Header("Debug / Control")]
    [SerializeField] private bool autoStart = false;
    [SerializeField] private bool debugReset = false;

    [Header("Limit opacity (0–1)")]
    [Range(0f, 1f)][SerializeField] private float maxAlpha = 0.62f;

    private bool isCoroutineRunning = false;

    private void Awake()
    {
        // Если спрайты заданы — ок, просто сохраняем текущие цвета
        if (NightMask == null || FadeMask == null)
        {
            Debug.LogError($"[{nameof(ScreenNight)}] NightMask и/или FadeMask не назначены!");
            enabled = false;
        }
    }

    private void Start()
    {
        if (NightMask == null || FadeMask == null)
            return;

        // Начинаем с прозрачных
        SetAlpha(FadeMask, 0f);
        SetAlpha(NightMask, 0f);

        if (autoStart)
            StartFullFade();
    }

    private void Update()
    {
        if (debugReset)
        {
            debugReset = false;
            StartFadeSequence();
        }
    }

    public void StartFadeSequence()
    {
        if (!isCoroutineRunning)
            StartCoroutine(FadeSequence());
    }

    public void StartFullFade()
    {
        StartCoroutine(FadeTo(maxAlpha));
    }



    private IEnumerator FadeSequence()
    {
        isCoroutineRunning = true;
        Debug.Log("[ScreenNight] Начало затемнения...");

        // Плавное затемнение (до maxAlpha)
        yield return StartCoroutine(FadeTo(maxAlpha));

        Debug.Log("[ScreenNight] Полное затемнение (ограничено " + maxAlpha + "). Ждём...");
        yield return new WaitForSeconds(waitTime);

        // Плавное осветление до нуля
        Debug.Log("[ScreenNight] Начало осветления...");
        yield return StartCoroutine(FadeTo(0f));

        Debug.Log("[ScreenNight] Эффект завершён.");
        isCoroutineRunning = false;
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        const float eps = 0.001f;
        float speed = Mathf.Max(0.0001f, fadeSpeed);

        // Не позволяем целевому альфа превышать maxAlpha
        targetAlpha = Mathf.Min(targetAlpha, maxAlpha);

        while (Mathf.Abs(FadeMask.color.a - targetAlpha) > eps ||
               Mathf.Abs(NightMask.color.a - targetAlpha) > eps)
        {
            float fadeStep = speed * Time.deltaTime;

            SetAlpha(FadeMask, Mathf.MoveTowards(FadeMask.color.a, targetAlpha, fadeStep));
            SetAlpha(NightMask, Mathf.MoveTowards(NightMask.color.a, targetAlpha, fadeStep));

            yield return null;
        }

        SetAlpha(FadeMask, targetAlpha);
        SetAlpha(NightMask, targetAlpha);
    }

    private void SetAlpha(SpriteRenderer sr, float a)
    {
        // clamp to 0..maxAlpha instead of 0..1
        a = Mathf.Clamp(a, 0f, maxAlpha);
        Color c = sr.color;
        c.a = a;
        sr.color = c;
    }
}
