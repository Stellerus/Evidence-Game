using Mono.Cecil.Cil;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
        public NumberAction() { }
    }



    private void Awake()
    {
        foreach (var num in numbers)
        {
            existingNumbers.Add(num.number);
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
            foreach (var number in existingNumbers)
            {
                if (number == dialedPhoneNumber)
                {
                    
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
