using UnityEngine;

public class PhoneCallingScript: MonoBehaviour
{
    public Transform diskCenter;      // ����� ����� (��������, ������ ������ � ������ �����)
    public float maxRotation = 120f;  // ������������ ���� ��������
    public float returnSpeed = 200f;  // �������� ��������
    public AudioSource tickSound;     // ���� ������� ��� �������� (�� �������)

    private bool isDragging = false;
    private float startAngle;
    private float currentRotation;
    private float targetRotation = 0f;
    private bool isReturning = false;

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(diskCenter.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            float delta = Mathf.DeltaAngle(startAngle, angle);
            delta = Mathf.Clamp(delta, 0, maxRotation);

            currentRotation = -delta; // ������� ������ �������
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
        else if (isReturning)
        {
            currentRotation = Mathf.MoveTowards(currentRotation, 0, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);

            if (Mathf.Approximately(currentRotation, 0))
                isReturning = false;
        }
    }

    void OnMouseDown()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(diskCenter.position);
        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        isDragging = true;
        isReturning = false;
    }

    void OnMouseUp()
    {
        isDragging = false;
        isReturning = true;

        // ����� ������ �������� ���������: ����� �������
        Debug.Log("����� �������: " + gameObject.name);
    }
}
