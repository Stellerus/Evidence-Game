using UnityEngine;

public class SpriteDropper : MonoBehaviour
{
    [Header("Позиция, куда опустить спрайт")]
    public Vector3 targetPosition;

    [Header("Скорость опускания (units/sec)")]
    public float dropSpeed = 5f;

    private Vector3 startPosition;
    private bool isDropping = false;

    void Start()
    {
        startPosition = transform.position; // Запоминаем изначальную позицию
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
            // Плавно перемещаем спрайт к целевой позиции
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, dropSpeed * Time.deltaTime);

            // Если достигли цели — останавливаем анимацию
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isDropping = false;
            }
        }
    }
}

