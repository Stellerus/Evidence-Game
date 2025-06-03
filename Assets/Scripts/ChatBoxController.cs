using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public DialogueSwitchS dialogueManager; // ������ �� ��� ������ � ������� ��������

    // ���������� ��� ����� �� ������
    public void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            dialogueManager.NextDialogue();
        }
    }
}
