using UnityEngine;

public class CameraZoomOnClick : MonoBehaviour
{
    public float zoomSize = 3f; // Размер камеры при увеличении
    public float zoomSpeed = 5f; // Скорость зума и перемещения
    public float normalSize = 5f; // Обычный размер камеры
    public float moveSpeed = 5f; // Скорость перемещения камеры

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
                // Клик по объекту — зумируемся к нему
                targetPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, cam.transform.position.z);
                targetSize = zoomSize;
                isZoomed = true;
            }
            else if (isZoomed)
            {
                // Клик по пустому месту — возвращаем камеру в исходное положение
                targetPosition = new Vector3(0, 0, cam.transform.position.z); // Можно задать нужную точку
                targetSize = normalSize;
                isZoomed = false;
            }
        }

        // Плавное перемещение камеры
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Плавное изменение размера камеры
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
    }
}
