using UnityEngine;

public class CameraZoomOnClick : MonoBehaviour
{
    public float zoomSize = 3f; // ������ ������ ��� ����������
    public float zoomSpeed = 5f; // �������� ���� � �����������
    public float normalSize = 5f; // ������� ������ ������
    public float moveSpeed = 5f; // �������� ����������� ������

    private Camera cam;
    private Vector3 targetPosition;
    private float targetSize;
    private bool isZoomed = false;

    void Start()
    {
        cam = Camera.main;
        targetPosition = cam.transform.position;
        targetSize = cam.orthographicSize;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                // ���� �� ������� � ���������� � ����
                targetPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, cam.transform.position.z);
                targetSize = zoomSize;
                isZoomed = true;
            }
            else if (isZoomed)
            {
                // ���� �� ������� ����� � ���������� ������ � �������� ���������
                targetPosition = new Vector3(0, 0, cam.transform.position.z); // ����� ������ ������ �����
                targetSize = normalSize;
                isZoomed = false;
            }
        }

        // ������� ����������� ������
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // ������� ��������� ������� ������
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
    }
}
