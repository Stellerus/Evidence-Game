using Mono.Cecil.Cil;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PhoneNumberHandler : MonoBehaviour
{
    [SerializeField]string dialedPhoneNumber;
    public int numberLength;

    //UnityEvent[] numberVariation;
    

    List<string> existingNumbers;

    [Serializable]
    public class NumberAction
    {
        public string number;
        public BaseAction_SO action;
        public NumberAction()
        {
            
        }
    }

    public void ClearNumber()
    {
        dialedPhoneNumber = string.Empty;
    }

    public void AddNumber(int phoneNumber)
    {
        dialedPhoneNumber += phoneNumber;
        Debug.Log($"Added {phoneNumber}. Current number is {dialedPhoneNumber}");

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
