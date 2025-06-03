using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PhoneCallingScript : MonoBehaviour
{
    [Header("Номер для действия")]
    public List<int> targetNumber = new List<int>() { 0, 0, 0 }; // Например, "123"
    public UnityEvent OnTargetNumberDialed; // Событие при совпадении

    [Header("Dial Settings")]
    public Transform diskCenter;      // Центр диска (пустой объект в центре)
    public float maxRotation = 270f;  // Максимальный угол набора (по часовой стрелке)
    public float returnSpeed = 200f;  // Скорость возврата (градусов в секунду)
    public float deadZone = 10f;
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
    private float currentAngle;
    private float prevAngle;
    private bool isReturning = false;
    private int currentStage = 0;

    public GameObject[] stage1Objects; // Для первого сценария
    public GameObject[] stage2Objects; // Для второго сценария
    public GameObject[] stage3Objects; // Для третьего сценария
    public GameObject[] stage4Objects; // Для четвёртого сценария

    void Update()
    {
        if (isDragging)
        {
            if (isDragging && Input.GetMouseButton(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = diskCenter.position.z;
                Vector2 dir = mouseWorldPos - diskCenter.position;
                float newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                float delta = Mathf.DeltaAngle(prevAngle, newAngle);
                prevAngle = newAngle;

                currentAngle = Mathf.Clamp(currentAngle - delta, 0, maxRotation);
                transform.localRotation = Quaternion.Euler(0, 0, -currentAngle);
            }
        }
        else if (isReturning)
        {
            float prevRotation = currentAngle;
            currentAngle = Mathf.MoveTowards(currentAngle, 0, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, -currentAngle);

            // Воспроизведение щелчка при прохождении каждого tickStep
            if (tickSound != null && Mathf.FloorToInt(Mathf.Abs(currentAngle / tickStep)) != Mathf.FloorToInt(Mathf.Abs(prevRotation / tickStep)))
            {
                tickSound.Play();
            }

            if (Mathf.Approximately(currentAngle, 0))
                isReturning = false;
        }
    }

    void OnMouseDown()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 centerScreen = Camera.main.WorldToScreenPoint(diskCenter.position);
        Vector2 dir = mousePos - centerScreen;

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

        if (dialedNumbers.Count == 3)
        {
            if (currentStage == 0 && dialedNumbers[0] == 0 && dialedNumbers[1] == 0 && dialedNumbers[2] == 0)
            {
                Debug.Log("Первый номер введён верно!");
                foreach (var obj in stage1Objects)
                    obj.SetActive(true);
                currentStage = 1;
                dialedNumbers.Clear();
            }
            else if (currentStage == 1)
            {
                StartCoroutine(Stage2Delay());
            }
            else if (currentStage == 2 && dialedNumbers[0] == 7 && dialedNumbers[1] == 7 && dialedNumbers[2] == 7)
            {
                Debug.Log("Второй номер введён верно!");
                foreach (var obj in stage3Objects)
                    obj.SetActive(true);
                currentStage = 3;
                dialedNumbers.Clear();
            }
            else if (currentStage == 3 && dialedNumbers[0] == 9 && dialedNumbers[1] == 9 && dialedNumbers[2] == 9)
            {
                Debug.Log("Третий номер введён верно!");
                foreach (var obj in stage4Objects)
                    obj.SetActive(true);
                currentStage = 4;
                dialedNumbers.Clear();
            }
            else
            {
                Debug.Log("Неверный номер! Начните сначала.");
                dialedNumbers.Clear();
            }
        }
        Debug.Log("Цифра выбрана: " + selectedNumber);
    }

    /// <summary>
    /// Вычисляет выбранную цифру по углу поворота.
    /// </summary>
    int CalculateNumber()
    {
        float positiveAngle = Mathf.Abs(currentAngle) - deadZone;
        if (positiveAngle < 0) positiveAngle = 0;

        float step = (maxRotation - deadZone) / (numbersCount - 1);
        int number = Mathf.RoundToInt(positiveAngle / step);

        // Смещаем на +1
        number += 1;

        // Ограничиваем диапазон (если 10 — это 0, как на дисковом телефоне)
        if (number >= numbersCount)
            number = 0;

        return number;
    }

    /// <summary>
    /// Сбросить набранный номер (можно вызвать из другого скрипта или UI)
    /// </summary>
    public void ClearDialedNumbers()
    {
        dialedNumbers.Clear();
    }
    public void SetTargetNumber(List<int> newNumber)
    {
        targetNumber = new List<int>(newNumber);
    }
    public IEnumerator Stage2Delay()
    {
        Debug.Log("Вам звонят!");
        yield return new WaitForSeconds(2f); // Задержка 2 секунды (можно изменить)
        Debug.Log("Вам позвонили!");
        foreach (var obj in stage2Objects)
            obj.SetActive(true);
        currentStage = 2;
        dialedNumbers.Clear();
    }
}