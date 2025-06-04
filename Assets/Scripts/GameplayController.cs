using System.Collections.Generic;
using UnityEngine;

public class DialogueSwitchS : MonoBehaviour
{
    public GameObject[] dialogueTexts; // Массив объектов текста
    public GameObject targetObject0;
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;

    private int currentIndex = 0;

    public PhoneCallingScript phoneCallingScript;
    public void NextDialogue()
    {
        // Выключаем текущий текст, если он есть
        if (currentIndex < dialogueTexts.Length)
            dialogueTexts[currentIndex].SetActive(false);

        currentIndex++;

        switch (currentIndex)
        {
            case 1:
                dialogueTexts[1].SetActive(true);
                break;
            case 2:
                dialogueTexts[2].SetActive(true);
                break;
            case 3:
                dialogueTexts[3].SetActive(true);
                break;
            case 4:
                dialogueTexts[4].SetActive(true);
                break;
            case 5:
                dialogueTexts[5].SetActive(true);
                break;
            case 6:
                dialogueTexts[6].SetActive(true);
                break;
            case 7:
                dialogueTexts[7].SetActive(true);
                break;
                case 8:
                    dialogueTexts[8].SetActive(true);
                break;
                case 9:
                phoneCallingScript.StartCoroutine(phoneCallingScript.Stage2Delay());
                gameObject.SetActive(false);
                targetObject0.SetActive(false);
                Character1.SetActive(false);
                break;
                case 10:
                dialogueTexts[10].SetActive(true);
                break;
                case 11:
                    dialogueTexts[11].SetActive(true);
                break;
                case 12:
                gameObject.SetActive(false);
                targetObject1.SetActive(false);
                break;
                case 13:
                    dialogueTexts[13].SetActive(true);
                break;
                case 14:
                    dialogueTexts[14].SetActive(true);
                break;
                case 15:
                    dialogueTexts[15].SetActive(true);
                break;
                case 16:
                    dialogueTexts[16].SetActive(true);
                break;
                case 17:
                    dialogueTexts[17].SetActive(true);
                break;
                case 18:
                    dialogueTexts[18].SetActive(true);
                break;
                case 19:
                gameObject.SetActive(false);
                targetObject2.SetActive(false);
                Character2.SetActive(false);
                break;
                case 20:
                    dialogueTexts[20].SetActive(true);
                break;
                case 21:
                    dialogueTexts[21].SetActive(true);
                break;
                case 22:
                    dialogueTexts[22].SetActive(true);
                break;
                case 23:
                    dialogueTexts[23].SetActive(true);
                break;
                case 24:
                    dialogueTexts[24].SetActive(true);
                break;
                case 25:
                    dialogueTexts[25].SetActive(true);
                break;
                case 26:
                    dialogueTexts[26].SetActive(true);
                break;
                case 27:
                    dialogueTexts[27].SetActive(true);
                break;
                case 28:
                    dialogueTexts[28].SetActive(true);
                break;
                case 29:
                    dialogueTexts[29].SetActive(true);
                break;
                case 30:
                    dialogueTexts[30].SetActive(true);
                break;
            case 31:
                dialogueTexts[31].SetActive(true);
                break;
                case 32:
                    dialogueTexts[32].SetActive(true);
                break;
            default:
                gameObject.SetActive(false);
                targetObject3.SetActive(false);
                Character3.SetActive(false);
                break;
        }
    }
}

