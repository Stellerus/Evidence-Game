using UnityEngine;

public class CameraZoomOnClick : MonoBehaviour
{
    public float zoomSize = 3f;     // Camera size when zoomed in
    public float zoomSpeed = 5f;    // Speed of camera size change
    public float startSize = 5f;    // Initial camera size
    public float moveSpeed = 5f;    // Camera movement speed

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
            Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);

            if (hit != null && hit.CompareTag("Player"))
            {
                // Clicked on an object with the "Player" tag — zoom in on it
                targetPosition = new Vector3(hit.transform.position.x, hit.transform.position.y, cam.transform.position.z);
                targetSize = zoomSize;
                isZoomed = true;
            }
            else if (isZoomed)
            {
                // Clicked on empty space — return camera to initial position
                targetPosition = new Vector3(0, 0, cam.transform.position.z);
                targetSize = startSize;
                isZoomed = false;
            }
        }

        // Smooth camera movement
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Smooth camera size change
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
    }
}
