using System.Runtime.CompilerServices;
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

    Collider2D hit;
    GameObject obj = null;

    int cachedLayer = 0;
    int finalLayer = 6;

    [SerializeField] private ScreenFocus focusVignette;

    void Awake()
    {
        cam = Camera.main;
        targetPosition = cam.transform.position;
        targetSize = cam.orthographicSize;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = MouseHit();


            if (hit != null && hit.CompareTag("Player"))
            {
                if (hit.gameObject != obj && obj != null)
                {
                    SpriteLayerElevator(obj, cachedLayer);
                }

                obj = hit.gameObject;

                Zoom();

                cachedLayer = SpriteLayerElevator(obj, finalLayer);
                focusVignette.BlurEnable();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {

            SpriteLayerElevator(obj, cachedLayer);
            focusVignette.BlurDisable();

            Unzoom();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            SpriteLayerElevator(obj, cachedLayer);
            focusVignette.BlurDisable();

            Unzoom();

        }

        // Smooth camera movement
        cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // Smooth camera size change
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);

        
    }

    private int SpriteLayerElevator(GameObject target, int layerNumber)
    {
        SpriteRenderer sprite = target.GetComponent<SpriteRenderer>();


        int previousLayer = sprite.sortingOrder;
        sprite.sortingOrder = layerNumber;
        
        Debug.Log($"Layer: {layerNumber} assigned to {target.name}\nCached: {previousLayer}");

        return previousLayer;
    }    

    private Collider2D MouseHit()
    {
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    private void Zoom()
    {
        targetPosition = new Vector3(hit.transform.position.x, hit.transform.position.y, cam.transform.position.z);
        targetSize = zoomSize;
        isZoomed = true;
    }

    private void Unzoom()
    {
        targetPosition = new Vector3(0, 0, cam.transform.position.z);
        targetSize = startSize;
        isZoomed = false;
    }
}
