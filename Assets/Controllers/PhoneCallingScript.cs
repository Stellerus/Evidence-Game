using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PhoneCallingScript : MonoBehaviour
{
    [Header("Dial Settings")]
    public Transform diskCenter;      // Центр диска (пустой объект в центре)
    public float maxRotation = 120f;  // Максимальный угол набора (по часовой стрелке)
    public float returnSpeed = 200f;  // Скорость возврата (градусов в секунду)
    public int numbersCount = 10;     // Количество цифр (обычно 10)

    [Header("Audio")]
    public AudioSource tickSound;     // Звук щелчка (опционально)
    public float tickStep = 12f;      // Через сколько градусов воспроизводить щелчок

    [Header("Events")]
    public UnityEvent<int> OnNumberSelected; // Событие выбора цифры

    [Header("Debug")]
    public List<int> dialedNumbers = new List<int>(); // Список набранных цифр

    private bool isDragging = false;
    private float startAngle;
    private float currentRotation;
    private bool isReturning = false;

    void Update()
    {
        if (isDragging)
        {
            Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(diskCenter.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            float delta = Mathf.DeltaAngle(startAngle, angle);

            // Разрешаем вращение только по часовой стрелке (от 0 до maxRotation)
            delta = Mathf.Clamp(delta, -maxRotation, 0); // только отрицательные значения

            currentRotation = delta;
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
        else if (isReturning)
        {
            float prevRotation = currentRotation;
            currentRotation = Mathf.MoveTowards(currentRotation, 0, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);

            // Воспроизведение щелчка при прохождении каждого tickStep
            if (tickSound != null && Mathf.FloorToInt(Mathf.Abs(currentRotation / tickStep)) != Mathf.FloorToInt(Mathf.Abs(prevRotation / tickStep)))
            {
                tickSound.Play();
            }

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
        int selectedNumber = CalculateNumber();
        dialedNumbers.Add(selectedNumber); // Добавляем в список
        if (OnNumberSelected != null)
            OnNumberSelected.Invoke(selectedNumber);
        Debug.Log("Цифра выбрана: " + selectedNumber);
    }

    /// <summary>
    /// Вычисляет выбранную цифру по углу поворота.
    /// </summary>
    int CalculateNumber()
    {
        float positiveAngle = Mathf.Abs(currentRotation);
        float step = maxRotation / (numbersCount - 1);
        int number = Mathf.RoundToInt(positiveAngle / step);

        // На дисковых телефонах 0 - это максимальный угол, 1 - минимальный
        // Поэтому инвертируем: 0 -> 0, 1 -> 9, 2 -> 8, ..., 9 -> 1
        int invertedNumber = (number == 0) ? 0 : numbersCount - number;
        if (invertedNumber == 10) invertedNumber = 0; // для 0

        return invertedNumber;
    }

    /// <summary>
    /// Сбросить набранный номер (можно вызвать из другого скрипта или UI)
    /// </summary>
    public void ClearDialedNumbers()
    {
        dialedNumbers.Clear();
    }
}