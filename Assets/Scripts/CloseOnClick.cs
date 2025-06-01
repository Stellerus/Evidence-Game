using UnityEngine;

public class HideOnClickOutside : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ���� Raycast �� ����� � ���� ������ � ��������� ���
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != gameObject)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                // ���� ���� �� ������� ����� � ���� ���������
                gameObject.SetActive(false);
            }
        }
    }
}

