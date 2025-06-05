using UnityEngine;

public class DialogueSwitchS : MonoBehaviour
{
    [Header("Text Objects")]
    [SerializeField] private GameObject[] dialogueTexts;
    [SerializeField] private float startDelay = 0.5f;
    [SerializeField] private GameObject MainCharacter;

    [Header("Scene Objects")]
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private GameObject[] characters;

    [Header("Dependencies")]
    [SerializeField] private PhoneCallingScript phoneCallingScript;
    [SerializeField] private PhoneCallBlink PhoneCallBlink;

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
            MainCharacter.SetActive(false);

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
            case 6:
                MainCharacter.SetActive(true);
                break;
            case 7:
                MainCharacter.SetActive(true); // Show main character
                break;
            case 10:
                MainCharacter.SetActive(true);
                break;
            case 12:
                MainCharacter.SetActive(true); // Show main character
                break;
            case 14:
                MainCharacter.SetActive(true);
                break;
            case 17:
                MainCharacter.SetActive(true); // Show main character
                break;
            case 23:
                MainCharacter.SetActive(true);
                break;
            case 24:
                MainCharacter.SetActive(true); // Show main character
                break;
            case 26:
                MainCharacter.SetActive(true);
                break;
            default:
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
            case 9:
                fader.Enable();
                ToggleObjects(false, 0);
                ToggleCharacter(false, 0);
                if (MainCharacter.activeSelf)
                    MainCharacter.SetActive(false);
                return true;

            case 17:
                fader.Enable();
                ToggleObjects(false, 1);
                ToggleCharacter(false, 1);
                if (MainCharacter.activeSelf)
                    MainCharacter.SetActive(false);
                return true;

            case 30:
                fader.Enable();
                ToggleObjects(false, 2);
                ToggleCharacter(false, 2);
                PhoneCallBlink.Invoke(nameof(PhoneCallBlink.StartRinging), 2f);
                if (MainCharacter.activeSelf)
                    MainCharacter.SetActive(false);
                return true;

            default:
                if (index >= dialogueTexts.Length)
                {
                    gameObject.SetActive(false);
                    if (MainCharacter.activeSelf)
                        MainCharacter.SetActive(false);
                    return true;
                }
                break;
        }
        return false;
    }

    private void ToggleObjects(bool state, int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < targetObjects.Length)
            targetObjects[targetIndex].SetActive(state);
    }

    private void ToggleCharacter(bool state, int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characters.Length)
            characters[characterIndex].SetActive(state);
    }
}


