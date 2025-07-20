using UnityEngine;

public class RingingDialogueSwitch : MonoBehaviour
{
    [Header("Text Objects")]
    [SerializeField] private GameObject[] dialogueTexts;
    [SerializeField] private float startDelay = 0.5f;

    [Header("Scene Objects")]
    [SerializeField] private GameObject[] targetObjects;

    private GameObject gol;
    private int currentIndex = -1;
    private Typewriter3DEffect currentTypewriter;

    void Start()
    {
        gol = GameObject.Find("Phone");
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
                if (gol != null)
                    gol.tag = "Player";
                return true;
            case 7:
                ToggleObjects(false, 1);
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