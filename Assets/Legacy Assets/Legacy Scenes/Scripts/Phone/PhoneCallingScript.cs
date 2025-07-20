using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PhoneCallingScript : MonoBehaviour
{
    [Header("Íîìåð äëÿ äåéñòâèÿ")]
    public List<int> targetNumber = new List<int>() { 0, 0, 0 };
    public UnityEvent OnTargetNumberDialed;

    [Header("Dial Settings")]
    public Transform diskCenter;
    public float maxRotation = 270f;
    public float returnSpeed = 200f;
    public float deadZone = 10f;
    public int numbersCount = 10;

    [Header("Audio")]
    public AudioSource tickSound;
    public float tickStep = 12f;

    [Header("Events")]
    public UnityEvent<int> OnNumberSelected;

    [Header("Debug")]
    public List<int> dialedNumbers = new List<int>();

    [Header("Manual Optioning")]
    [SerializeField] private DigitAnglePair[] digitAngles;

    [Serializable]
    public class DigitAnglePair
    {
        public int digit;
        [Tooltip("min angle")]
        public float minAngle;
        [Tooltip("max angle")]
        public float maxAngle;
    }

    private bool isDragging = false;
    private float startAngle;
    private float currentAngle;
    private float prevAngle;
    private bool isReturning = false;
    private int currentStage = 0;

    public GameObject[] stage1Objects;
    public GameObject[] stage3Objects;
    public GameObject[] stage4Objects;
    public ScreenFader screenFader;

    void Update()
    {
        if (isDragging)
        {
            if (Input.GetMouseButton(0))
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
        dialedNumbers.Add(selectedNumber);
        OnNumberSelected?.Invoke(selectedNumber);

        if (dialedNumbers.Count == 3)
        {
            if (currentStage == 0 && dialedNumbers.SequenceEqual(new[] { 5, 9, 2 }))
            {
                HandleCorrectInput(stage1Objects, 1);
            }
            else if (currentStage == 1 && dialedNumbers.SequenceEqual(new[] { 2, 1, 3 }))
            {
                HandleCorrectInput(stage3Objects, 2);
            }
            else if (currentStage == 2 && dialedNumbers.SequenceEqual(new[] { 6, 0, 6 }))
            {
                HandleCorrectInput(stage4Objects, 3);
            }
            else
            {
                Debug.Log("Invalid number! Please start over.");
                dialedNumbers.Clear();
            }
        }
        Debug.Log("Selected digit: " + selectedNumber);
    }

    int CalculateNumber()
    {
        float currentAngle = Mathf.Abs(transform.localEulerAngles.z);

        foreach (var pair in digitAngles)
        {
            if (currentAngle >= pair.minAngle && currentAngle < pair.maxAngle)
            {
                Debug.Log($"Угол: {currentAngle}° → Цифра: {pair.digit}");
                return pair.digit;
            }
        }

        Debug.LogWarning($"Угол {currentAngle}° не попадает ни в один диапазон!");
        return 0; // fallback
    }




    void HandleCorrectInput(GameObject[] objectsToActivate, int newStage)
    {
        Debug.Log($"Stage {newStage} correct!");
        screenFader.Enable();
        foreach (var obj in objectsToActivate)
            obj.SetActive(true);
        currentStage = newStage;
        dialedNumbers.Clear();
    }

    public void ClearDialedNumbers() => dialedNumbers.Clear();
    public void SetTargetNumber(List<int> newNumber) => targetNumber = new List<int>(newNumber);
}
