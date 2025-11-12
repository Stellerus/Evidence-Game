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

    public TextMesh optionalMesh;
    public bool optionalMeshActive = false;

    [Serializable]
    public class NumberAction
    {
        public bool Unlocked;

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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {

        }
        if (optionalMesh != null)
        {
            optionalMesh.text = dialedPhoneNumber;
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


    public void UnlockNumberAdelina()
    {
        UnlockNumber("613");
    }
    public void UnlockNumberVictor()
    {
        UnlockNumber("047");
    }

    public void LockNumberAdelina()
    {
        LockNumber("613");
    }
    public void LockNumberVictor()
    {
        LockNumber("047");
    }

    

    private void UnlockNumber(string number)
    {
        foreach (var num in numbers)
        {
            if (num.number == dialedPhoneNumber && num.number == number)
            {
                num.Unlocked = true;
            }
        }
    }
    private void LockNumber(string number)
    {
        foreach (var num in numbers)
        {
            if (num.number == dialedPhoneNumber && num.number == number)
            {
                num.Unlocked = false;
            }
        }
    }

    private void CheckPhoneNumber()
    {
        if (existingNumbers.Contains(dialedPhoneNumber))
        {
            foreach (var num in numbers)
            {
                if (num.number == dialedPhoneNumber )
                {
                    if (num.Unlocked)
                    {
                        num.action.Invoke();
                    }
                    else
                    {
                        Debug.Log($"{num.number} needs to be unlocked");
                    }
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
