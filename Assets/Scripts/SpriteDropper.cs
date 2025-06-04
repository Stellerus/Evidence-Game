using UnityEngine;

public class SpriteDropper : MonoBehaviour
{
    [Header("�������, ���� �������� ������")]
    public Vector3 targetPosition;

    [Header("�������� ��������� (units/sec)")]
    public float dropSpeed = 5f;

    private Vector3 startPosition;
    private bool isDropping = false;

    void Start()
    {
        startPosition = transform.position; // ���������� ����������� �������
        StartDrop();
    }

    public void StartDrop()
    {
        isDropping = true;
    }

    void Update()
    {
        if (isDropping)
        {
            // ������ ���������� ������ � ������� �������
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, dropSpeed * Time.deltaTime);

            // ���� �������� ���� � ������������� ��������
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isDropping = false;
            }
        }
    }
}

