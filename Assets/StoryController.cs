using System;
using UnityEngine;
using UnityEngine.Events;

public class StoryController : MonoBehaviour
{
    //[Serializable]
    //public class BoolEventPair
    //{
    //    public bool value;
    //    public UnityEvent action;
    //}


    public bool TutorialEnded { get; private set; }


    [Header("Phone")]
    public bool PhoneUnlocked { get; private set; }
    public bool Character1Unlocked { get; private set; }
    public UnityEvent UnlockCharacter1Event;
    public bool Character2Unlocked { get; private set; }
    public UnityEvent UnlockCharacter2Event;
    public bool Character3Unlocked { get; private set; }
    public UnityEvent UnlockCharacter3Event;


    [Header("Interrogation")]
    public bool Character1Interrogated { get; private set; }
    public UnityEvent InterrogationEvent1;
    public bool Character2Interrogated { get; private set; }
    public UnityEvent InterrogationEvent2;
    public bool Character3Interrogated { get; private set; }
    public UnityEvent InterrogationEvent3;


    int maxDays;
    int currentDay;

    [Header("Days")]
    public bool Day1 { get; private set; }
    public UnityEvent Day1Action;
    public bool Day2 { get; private set; }
    public UnityEvent Day2Action;
    public bool Day3 { get; private set; }
    public UnityEvent Day3Action;
    public bool Day4 { get; private set; }
    public UnityEvent Day4Action;
    public bool Day5 { get; private set; }
    public UnityEvent Day5Action;


    
    public void InterrogateCharacter1()
    {
        InterrogationEvent1.Invoke();
        Character1Interrogated = true;
    }

    public void InterrogateCharacter2()
    {
        InterrogationEvent1.Invoke();
        Character1Interrogated = true;
    }

    public void InterrogateCharacter3()
    {
        InterrogationEvent1.Invoke();
        Character1Interrogated = true;
    } 




    public void UnlockCharacter1()
    {
        UnlockCharacter1Event.Invoke();
        Character1Unlocked = true;
    }

    public void UnlockCharacter2()
    {
        UnlockCharacter2Event.Invoke();
        Character2Unlocked = true;
    }

    public void UnlockCharacter3()
    {
        UnlockCharacter3Event.Invoke();
        Character3Unlocked = true;
    }




    void Initialize()
    {
        maxDays = 5;
        currentDay = 0;
    }

    public void NextDay()
    {
        if (currentDay == 1)
        {
            Day1Action.Invoke();
        }
        if (currentDay == 2)
        {
            Day2Action.Invoke();
        }
        if (currentDay == 3)
        {
            Day3Action.Invoke();
        }
        if (currentDay == 4)
        {
            Day4Action.Invoke();
        }
        if (currentDay == 5)
        {
            Day5Action.Invoke();
        }
        if (currentDay < maxDays)
        {
            currentDay += 1;
        }
        Debug.Log($"{currentDay} day set");
    }

    private void Awake()
    {
        Initialize();
    }
}
