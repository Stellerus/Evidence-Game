using UnityEngine;

public class PhoneCallBlink : MonoBehaviour
{
    [SerializeField] private GameObject[] targetObjects;
    public SpriteRenderer spriteRenderer; // ���� ��������� ������ SpriteRenderer
    public AudioSource ringAudioSource;   // ���� ��������� AudioSource � ���������
    public float blinkInterval = 0.5f;    // �������� ������� � ��������

    private bool isRinging = false;
    private bool isBlinking = false;
    private int scenario = 0;
    void Start()
    {
        Invoke(nameof(StartRinging), 2f);
        gameObject.tag = "Untagged";
    }

    void Update()
    {
        if (isRinging && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (spriteRenderer.bounds.Contains(mousePos))
            {
                StopRinging();

                scenario++;

                switch (scenario)
                {
                    case 1:
                        targetObjects[scenario - 1].SetActive(true);
                        break;
                    case 2:
                        targetObjects[scenario - 1].SetActive(true);
                        break;
                }
            }
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
        spriteRenderer.enabled = false; // �������� ������ �������
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

