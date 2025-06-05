using UnityEngine;

public class StorageDialogueSwitch : MonoBehaviour
{
    [Header("Text Objects")]
    [SerializeField] private GameObject[] dialogueTexts;
    [SerializeField] private GameObject MainCharacter;
    [SerializeField] private float startDelay = 0.5f;

    [Header("Scene Objects")]
    [SerializeField] private GameObject[] targetObjects;

    [SerializeField] private ScreenFader fader;

    private int currentIndex = -1;
    private Typewriter3DEffect currentTypewriter;

    void Start()
    {
        InitializeTextObjects();
    }

    private void InitializeTextObjects()
    {
        foreach (var textObj in dialogueTexts)
        {
            if (textObj != null)
            {
                textObj.SetActive(false);
                var tw = textObj.GetComponent<Typewriter3DEffect>();
                if (tw != null) tw.enabled = true;
            }
        }
    }

    public void NextDialogue()
    {
        if (MainCharacter.activeSelf)
            MainCharacter.SetActive(false); // Hide main character if active

       
        // Turning off the previous text
        if (currentIndex >= 0 && currentIndex < dialogueTexts.Length)
        {
            if (dialogueTexts[currentIndex] != null)
            {
                dialogueTexts[currentIndex].SetActive(false);
                if (currentTypewriter != null)
                    currentTypewriter.SkipTyping();
            }
        }

        currentIndex++;

        switch (currentIndex)
        {
            case 0:
                MainCharacter.SetActive(true); // Show main character
                break;
            case 2:
                MainCharacter.SetActive(true);
                break;
            case 4:
                MainCharacter.SetActive(true);
                break;
            case 5:
                MainCharacter.SetActive(true); // Show main character
                break;
        }


        if (HandleSpecialCases(currentIndex))
            return; // If a special case is handled, exit early

        // Activating the next text
        if (currentIndex < dialogueTexts.Length && dialogueTexts[currentIndex] != null)
        {
            dialogueTexts[currentIndex].SetActive(true);
            currentTypewriter = dialogueTexts[currentIndex].GetComponent<Typewriter3DEffect>();
            if (currentTypewriter != null)
                currentTypewriter.StartTyping();
        }
    }

    private bool HandleSpecialCases(int index)
    {
        switch (index)
        {
            case 5:
                ToggleObjects(false, 0);
                ToggleObjects(true, 1);
                ToggleObjects(true, 2);
                MainCharacter.SetActive(false);
                return true;
            case 8:
                ToggleObjects(false, 0);
                MainCharacter.SetActive(false);
                return true;
        }
        return false;
    }

    private void ToggleObjects(bool state, int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < targetObjects.Length)
            targetObjects[targetIndex].SetActive(state);
    }
}