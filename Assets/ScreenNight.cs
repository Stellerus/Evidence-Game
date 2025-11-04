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
    [SerializeField] private bool autoStart = false; // если true — запустить при Start()
    [SerializeField] private bool debugReset = false;

    private bool isCoroutineRunning = false;

    private float nightMaskOrigAlpha = 1f;
    private float fadeMaskOrigAlpha = 1f;

    private void Awake()
    {
        // Сохраняем исходные альфы (если спрайты заданы)
        if (NightMask != null)
            nightMaskOrigAlpha = NightMask.color.a;
        if (FadeMask != null)
            fadeMaskOrigAlpha = FadeMask.color.a;
    }

    private void Start()
    {
        // Проверки на назначенные спрайты
        if (NightMask == null || FadeMask == null)
        {
            Debug.LogError($"[{nameof(ScreenNight)}] NightMask и/или FadeMask не назначены в инспекторе. Присвойте SpriteRenderer'ы.");
            enabled = false; // отключаем скрипт, чтобы не получать NRE
            return;
        }

        // Делает их полностью прозрачными при старте (как в твоём варианте)
        SetAlpha(FadeMask, 0f);
        SetAlpha(NightMask, 0f);

        if (autoStart)
            StartFade();
    }

    private void Update()
    {
        if (debugReset)
        {
            debugReset = false;
            StartFade();
        }
    }

    /// <summary>
    /// Вызвать извне, чтобы запустить эффект затемнения/осветления.
    /// </summary>
    public void StartFade()
    {
        if (!isCoroutineRunning)
            StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        isCoroutineRunning = true;
        Debug.Log("[ScreenNight] Начало затемнения...");

        // Затемнение до полной (1)
        yield return StartCoroutine(FadeTo(1f));

        Debug.Log("[ScreenNight] Полное затемнение. Ждём...");
        yield return new WaitForSeconds(waitTime);

        // Осветление до исходных (в данном случае до 0)
        Debug.Log("[ScreenNight] Начало осветления...");
        yield return StartCoroutine(FadeTo(0f));

        Debug.Log("[ScreenNight] Эффект завершён.");
        isCoroutineRunning = false;
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        // Защита от нулевой скорости
        float speed = Mathf.Max(0.0001f, fadeSpeed);

        // Используем небольшое эпсилон-окно для завершения
        const float eps = 0.001f;

        while (Mathf.Abs(FadeMask.color.a - targetAlpha) > eps ||
               Mathf.Abs(NightMask.color.a - targetAlpha) > eps)
        {
            float fadeStep = speed * Time.deltaTime;

            SetAlpha(FadeMask, Mathf.MoveTowards(FadeMask.color.a, targetAlpha, fadeStep));
            SetAlpha(NightMask, Mathf.MoveTowards(NightMask.color.a, targetAlpha, fadeStep));

            yield return null;
        }

        // Устанавливаем точно целевую альфу (избежать мелких погрешностей)
        SetAlpha(FadeMask, targetAlpha);
        SetAlpha(NightMask, targetAlpha);
    }

    private void SetAlpha(SpriteRenderer sr, float a)
    {
        Color c = sr.color;
        c.a = Mathf.Clamp01(a);
        sr.color = c;
    }
}
