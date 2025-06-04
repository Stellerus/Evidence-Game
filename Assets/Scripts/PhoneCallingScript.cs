using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PhoneCallingScript : MonoBehaviour
{
    [Header("Íîìåð äëÿ äåéñòâèÿ")]
    public List<int> targetNumber = new List<int>() { 0, 0, 0 }; // Example: "123"
    public UnityEvent OnTargetNumberDialed; // Answers for the survey

    [Header("Dial Settings")]
    public Transform diskCenter;      // Disk center (empty object at the center)
    public float maxRotation = 270f;  // Maximum height of the slope (by time of day)
    public float returnSpeed = 200f;  // Wind speed (meters per second)
    public float deadZone = 10f;
    public int numbersCount = 10;     // Number of digits (usually 10)

    [Header("Audio")]
    public AudioSource tickSound;     // Smoke density (optional)
    public float tickStep = 12f;      // How many degrees to raise the smoke through the chimney

    [Header("Events")]
    public UnityEvent<int> OnNumberSelected; // Digit selection answers

    [Header("Debug")]
    public List<int> dialedNumbers = new List<int>(); // List of selected digits

    private bool isDragging = false;
    private float startAngle;
    private float currentAngle;
    private float prevAngle;
    private bool isReturning = false;
    private int currentStage = 0;

    public GameObject[] stage1Objects; // For the 1st scene
    public GameObject[] stage2Objects; // For the 2nd scene
    public GameObject[] stage3Objects; // For the 3rd scene
    public GameObject[] stage4Objects; // For the 4th scene

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

            // Smoke rise speed for each tickStep increment
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
        dialedNumbers.Add(selectedNumber); // Adding to the list
        if (OnNumberSelected != null)
            OnNumberSelected.Invoke(selectedNumber);

        if (dialedNumbers.Count == 3)
        {
            if (currentStage == 0 && dialedNumbers[0] == 0 && dialedNumbers[1] == 0 && dialedNumbers[2] == 0)
            {
                Debug.Log("The first number entered is correct!");
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
                Debug.Log("The second number entered is correct!");
                foreach (var obj in stage3Objects)
                    obj.SetActive(true);
                currentStage = 3;
                dialedNumbers.Clear();
            }
            else if (currentStage == 3 && dialedNumbers[0] == 9 && dialedNumbers[1] == 9 && dialedNumbers[2] == 9)
            {
                Debug.Log("The third number entered is correct!");
                foreach (var obj in stage4Objects)
                    obj.SetActive(true);
                currentStage = 4;
                dialedNumbers.Clear();
            }
            else
            {
                Debug.Log("Invalid number! Please start over.");
                dialedNumbers.Clear();
            }
        }
        Debug.Log("Selected digit: " + selectedNumber);
    }

    /// <summary>
    /// Extracts the selected digit according to the pointer position.
    /// </summary>
    int CalculateNumber()
    {
        float positiveAngle = Mathf.Abs(currentAngle) - deadZone;
        if (positiveAngle < 0) positiveAngle = 0;

        float step = (maxRotation - deadZone) / (numbersCount - 1);
        int number = Mathf.RoundToInt(positiveAngle / step);

        // Shifted by +1
        number += 1;

        // We consider the dial (if 10 — that means 0, like on a telephone keypad).
        if (number >= numbersCount)
            number = 0;

        return number;
    }

    /// <summary>
    /// Display the entered number (can be called from another script or UI).
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
        Debug.Log("Âàì çâîíÿò!");
        yield return new WaitForSeconds(2f); // Task for 2 seconds (can be changed)
        Debug.Log("Âàì ïîçâîíèëè!");
        foreach (var obj in stage2Objects)
            obj.SetActive(true);
        currentStage = 2;
        dialedNumbers.Clear();
    }
}
