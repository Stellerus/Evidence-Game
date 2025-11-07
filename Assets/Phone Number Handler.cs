using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneNumberHandler : MonoBehaviour
{
    [SerializeField] string dialedPhoneNumber;
    public int numberLength;

    private List<string> existingNumbers;
    public List<NumberAction> numbers;

    [Serializable]
    public class NumberAction
    {
        public string number;
        public UnityEvent action;
    }



    private void Awake()
    {
        ClearNumber();
        existingNumbers = new List<string>();
        foreach (var num in numbers)
        {
            if (num != null)
            {
                existingNumbers.Add(num.number);
            }
        }
    }



    public void ClearNumber()
    {
        dialedPhoneNumber = string.Empty;
    }

    public void AddNumber(char digit)
    {
        dialedPhoneNumber += digit;
        Debug.Log($"Added {digit}. Current number is {dialedPhoneNumber}");

        if (dialedPhoneNumber.Length >= numberLength)
        {
            CheckPhoneNumber();
        }
    }

    private void CheckPhoneNumber()
    {
        if (existingNumbers.Contains(dialedPhoneNumber))
        {
            foreach (var num in numbers)
            {
                if (num.number == dialedPhoneNumber)
                {
                    num.action.Invoke();
                }
            }
        }
        else
        {
            Debug.Log($"{dialedPhoneNumber} is not in existing numbers");
        }

        ClearNumber();
    }
}
