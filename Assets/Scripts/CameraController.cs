using UnityEngine;

public class CameraZoomOnClick : MonoBehaviour
{
    public float zoomSize = 3f; // Size of zoom camera
    public float zoomSpeed = 5f; // Speed ​​of sound and movement
    public float startSize = 5f; // Start camera size
    public float moveSpeed = 5f; // Speed ​​of camera movement

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
                // Click on an object — zoom to it
                targetPosition = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, cam.transform.position.z);
                targetSize = zoomSize;
                isZoomed = true;
            }
            else if (isZoomed)
            {
                // Click on an empty place — return the camera to its original position
                targetPosition = new Vector3(0, 0, cam.transform.position.z);
                targetSize = normalSize;
                isZoomed = false;
            }
        }

        // Smooth camera movement
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Smooth camera resizing
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
    }
}
