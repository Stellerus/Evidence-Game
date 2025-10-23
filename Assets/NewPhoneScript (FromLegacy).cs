using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class NewPhoneScriptFromLegacy : MonoBehaviour
{
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



    private bool isReturning = false;
    private bool isDragging = false;

    private float startAngle;
    private float currentAngle;
    private float prevAngle;



    public ScreenFader screenFader;

    void Update()
    {
        if (isDragging && Input.GetMouseButton(0)) // Disk Dragging Check
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
        else if (isReturning) // Disk returns to its position
        {
            ReturnDisk();
        }
    }

    void OnMouseDown()
    {
        Vector2 mousePos = Input.mousePosition; // Get mouse position
        Vector2 centerScreen = Camera.main.WorldToScreenPoint(diskCenter.position); // center of the screen
        Vector2 dir = mousePos - centerScreen; // Direction Vector

        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // Degree of start

        isDragging = true;
        isReturning = false;
    }

    void OnMouseUp()
    {
        isDragging = false;
        isReturning = true;

        int selectedNumber = CalculateNumber();
        dialedNumbers.Add(selectedNumber);

        OnNumberSelected?.Invoke(selectedNumber); // Invoke Event

        if (dialedNumbers.Count == 3) //if count of numbers is 3
        {
            // if dialedNumbers are 592
            //if (currentStage == 0 && dialedNumbers.SequenceEqual(new[] { 5, 9, 2 }))
            //{
            //    HandleCorrectInput(stage1Objects, 1);
            //}
            if (true)
            {

            }
            else
            {
                Debug.Log("Invalid number! Please start over.");
                dialedNumbers.Clear();
            }
        }
        Debug.Log("Selected digit: " + selectedNumber);
    }


    private void ReturnDisk()
    {
        float prevRotation = currentAngle;
        currentAngle = Mathf.MoveTowards(currentAngle, 0, returnSpeed * Time.deltaTime); // Starts moving to Zero Point
        transform.rotation = Quaternion.Euler(0, 0, -currentAngle);

        //if (tickSound != null && Mathf.FloorToInt(Mathf.Abs(currentAngle / tickStep)) != Mathf.FloorToInt(Mathf.Abs(prevRotation / tickStep)))
        //{
        //    tickSound.Play();
        //}

        if (Mathf.Approximately(currentAngle, 0)) // Stops returning (sets false)
            isReturning = false;
    }


    int CalculateNumber()
    {
        float currentAngle = Mathf.Abs(transform.localEulerAngles.z);

        foreach (DigitAnglePair pair in digitAngles) // Shizophreny (min and max angle are in DAPair and 
        {
            if (currentAngle >= pair.minAngle && currentAngle < pair.maxAngle)
            {
                Debug.Log($"Angle: {currentAngle}° → digit: {pair.digit}");
                return pair.digit;
            }
        }

        Debug.LogWarning($"Angle {currentAngle}° is not in Range");
        return 0;
    }

    public void ClearDialedNumbers() => dialedNumbers.Clear();
    public void SetTargetNumber(List<int> newNumber) => targetNumber = new List<int>(newNumber);
}
