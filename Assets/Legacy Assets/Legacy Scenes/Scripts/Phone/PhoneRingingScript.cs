using UnityEngine;

public class PhoneCallBlink : MonoBehaviour
{
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private IL IL;
    public SpriteRenderer spriteRenderer; // —юда назначьте нужный SpriteRenderer
    public AudioSource ringAudioSource;   // —юда назначьте AudioSource с рингтоном
    public float blinkInterval = 0.5f;    // »нтервал мигани€ в секундах

    private bool isRinging = false;
    private bool isBlinking = false;
    public int scenario = 0;
    void Start()
    {
        Invoke(nameof(StartRinging), 2f);
        gameObject.tag = "Untagged";
    }

    void OnMouseDown()
    {

        switch (scenario)
        {
            case 0:
                targetObjects[scenario].SetActive(true);
                StopRinging();
                scenario++;
                break;
            case 2:
                targetObjects[scenario - 1].SetActive(true);
                scenario++;
                StopRinging();
                IL.scenario = 2;
                break;
        }
    }


    public void StartRinging()
    {
        isRinging = true;
        //ringAudioSource.loop = true;
        //ringAudioSource.Play();
        StartCoroutine(BlinkCoroutine());
    }

    public void StopRinging()
    {
        isRinging = false;
        //ringAudioSource.Stop();
        StopCoroutine(BlinkCoroutine());
        spriteRenderer.enabled = false; // ¬ключаем спрайт обратно
    }

    private System.Collections.IEnumerator BlinkCoroutine()
    {
        isBlinking = true;
        while (isRinging)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
        spriteRenderer.enabled = false;
        isBlinking = false;
    }
}

