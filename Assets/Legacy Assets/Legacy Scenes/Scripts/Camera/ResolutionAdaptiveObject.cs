using UnityEngine;

public class ResolutionAdaptiveObject : MonoBehaviour
{
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private Camera cam;
    private float initialOrthographicSize;

    void Start()
    {
        cam = Camera.main;
        initialScale = transform.localScale;
        initialPosition = transform.position;
        initialOrthographicSize = cam.orthographicSize;
    }

    void Update()
    {
        if (cam.orthographic)
        {
            float scaleFactor = cam.orthographicSize / initialOrthographicSize;
            transform.localScale = initialScale * scaleFactor;
            transform.position = initialPosition * scaleFactor;
        }
    }
}