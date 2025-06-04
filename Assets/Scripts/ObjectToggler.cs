using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    // ������ ��������, ������� ����� ����������/�����������
    public GameObject[] objectsToToggle;
    public GameObject ParentObjectToToggle;

    // ���� ����� ����������, ����� ������������ ������� ����� �� Collider'� ����� GameObject'�
    void OnMouseDown()
    {
        // �������� ������ ������ �� �������
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null) // ���������, ��� ������ �������� � �������
            {
                obj.SetActive(true); // ������ ������ ��������
            }
        }
    }

    // ����� Update ���������� ������ ����
    void Update()
    {
        // ���������, ������ �� ������� Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ��������� ������ ������ �� �������
            foreach (GameObject obj in objectsToToggle)
            {
                if (obj != null) // ���������, ��� ������ �������� � �������
                {
                    obj.SetActive(false); // ������ ������ ����������
                }
            }
        }
    }
}
