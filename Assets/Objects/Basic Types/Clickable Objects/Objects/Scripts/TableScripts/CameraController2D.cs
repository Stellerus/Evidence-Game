using UnityEngine;

public class CameraController2D : MonoBehaviour
{
    [Header("Zoom settings")]
    public float zoomSpeed = 5f;
    public float minSize = 2f;
    public float maxSize = 10f;

    [Header("Camera bounds")]
    public Transform tableBounds;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic)
            Debug.LogWarning("CameraController2D work only with Orthographic camera");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            float scroll = Input.mouseScrollDelta.y;
            if (scroll != 0)
            {
                ZoomToMouse(scroll);
                ClampCameraToBounds();
            }
        }
    }

    private void ZoomToMouse(float scroll)
    {
        Vector3 mouseWorldBeforeZoom = cam.ScreenToWorldPoint(Input.mousePosition);

        cam.orthographicSize -= scroll * zoomSpeed * Time.deltaTime;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);

        Vector3 mouseWorldAfterZoom = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mouseWorldBeforeZoom - mouseWorldAfterZoom;
        cam.transform.position += diff;
    }

    private void ClampCameraToBounds()
    {
        if (tableBounds == null) return;

        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * cam.aspect;

        Vector3 min = tableBounds.position - tableBounds.localScale / 2f;
        Vector3 max = tableBounds.position + tableBounds.localScale / 2f;

        Vector3 pos = cam.transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + horzExtent, max.x - horzExtent);
        pos.y = Mathf.Clamp(pos.y, min.y + vertExtent, max.y - vertExtent);
        cam.transform.position = pos;
    }
}
