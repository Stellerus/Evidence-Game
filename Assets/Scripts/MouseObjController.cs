using UnityEngine;
using UnityEngine.Events;

public class MouseObjController : MonoBehaviour
{
    public UnityEvent OnMouseObjTrigger;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���������� ������ � ������� ����
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            transform.position = mouseWorldPos;

            // ���� ������ ��� ���������, ������ �������
            if (!GetComponent<SpriteRenderer>().enabled)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("MouseObj is within object: " + other.gameObject.name);

            OnMouseObjTrigger?.Invoke();

            // ������ ������ ��������� � ��������� ���������
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

