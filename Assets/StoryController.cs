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


    [Header("Dialogues")]

    [Header("Day 2")]
    public bool DialogueWithJanDay2Ended;
    public UnityEvent DialogueWithJanDay2Event;

    public void DialogueWithJanDay2()
    {
        DialogueWithJanDay2Event.Invoke();
        DialogueWithJanDay2Ended = true;
    }

    public bool DialogueWithKobelDay2Ended;
    public UnityEvent DialogueWithKobelDay2Event;

    public void DialogueWithKobelDay2()
    {
        DialogueWithKobelDay2Event.Invoke();
        DialogueWithKobelDay2Ended = true;
    }

    public bool DialogueWithIlyishnaDay2Ended;
    public UnityEvent DialogueWithIlyishnaDay2Event;

    public void DialogueWithIlyishnaDay2()
    {
        DialogueWithIlyishnaDay2Event.Invoke();
        DialogueWithIlyishnaDay2Ended = true;
    }

    public bool MonologueMcDay2Ended;
    public UnityEvent MonologueMcDay2Event;

    public void MonologueMcDay2()
    {
        MonologueMcDay2Event.Invoke();
        MonologueMcDay2Ended = true;
    }


    [Header("Day 3")]
    public bool DialogueWithIlyishnaDay3Ended;
    public UnityEvent DialogueWithIlyishnaDay3Event;

    public void DialogueWithIlyishnaDay3()
    {
        DialogueWithIlyishnaDay3Event.Invoke();
        DialogueWithIlyishnaDay3Ended = true;
    }

    public bool InterrogateAdelinaDay3Ended { get; private set; }
    public UnityEvent InterrogationEventAdelinaDay3;

    public void InterrogateAdelinaDay3()
    {
        InterrogationEventAdelinaDay3.Invoke();
        InterrogateAdelinaDay3Ended = true;
    }


    public bool DialogueWithKobelDay3Ended;
    public UnityEvent DialogueWithKobelDay3Event;

    public void DialogueWithKobelDay3()
    {
        DialogueWithKobelDay3Event.Invoke();
        DialogueWithKobelDay3Ended = true;
    }

    public bool InterrogateVictorDay3Ended { get; private set; }
    public UnityEvent InterrogationEventVictorDay3;

    public void InterrogateVictorDay3()
    {
        InterrogationEventVictorDay3.Invoke();
        InterrogateVictorDay3Ended = true;
    }

    [Header("Day 4")]
    public bool DilogueWithKobelDay4Ended;
    public UnityEvent DilogueWithKobelDay4Event;

    //The End;

    [Header("Interrogation")]
    

    


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

    private void Start()
    {
        NextDay();
    }
}
