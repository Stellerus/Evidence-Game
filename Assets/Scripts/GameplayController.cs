using UnityEngine;

public class DialogueSwitchS : MonoBehaviour
{
    public GameObject[] dialogueTexts; // Массив объектов текста
    public GameObject targetObject0;
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    private int currentIndex = 0;

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
                // Здесь можно добавить уникальную логику для второго текста
                break;
            case 2:
                dialogueTexts[2].SetActive(true);
                // Уникальная логика для третьего текста
                break;
            case 3:
                dialogueTexts[3].SetActive(true);
                // Здесь можно добавить уникальную логику для второго текста
                break;
            case 4:
                dialogueTexts[4].SetActive(true);
                // Здесь можно добавить уникальную логику для второго текста
                break;
            case 5:
                dialogueTexts[5].SetActive(true);
                gameObject.SetActive(false);
                targetObject0.SetActive(false);
                break;
            case 6:
                dialogueTexts[6].SetActive(true);
                // Здесь можно добавить уникальную логику для второго текста
                break;
            case 7:
                dialogueTexts[7].SetActive(true);
                // Здесь можно добавить уникальную логику для второго текста
                break;
                case 8:
                    dialogueTexts[8].SetActive(true);
            // Здесь можно добавить уникальную логику для второго текста
            break;
                case 9:
                    dialogueTexts[9].SetActive(true);
            // Здесь можно добавить уникальную логику для второго текста
            break;
                case 10:
                    dialogueTexts[10].SetActive(true);
                break;
                case 11:
                    dialogueTexts[11].SetActive(true);
                break;
                case 12:
                    dialogueTexts[12].SetActive(true);
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
                    dialogueTexts[19].SetActive(true);
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
            default:
                // Все диалоги закончились
                Debug.Log("Диалог завершён");
                break;
        }
    }
}

