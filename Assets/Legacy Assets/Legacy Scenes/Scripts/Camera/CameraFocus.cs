using UnityEngine;
using UnityEngine.UI;

public class CameraFocus : MonoBehaviour
{
    public Transform defaultPosition;       // Initial camera position
    public float moveSpeed = 2f;            // Camera movement speed
    private Transform targetFocus;          // Current camera target

    public GameObject backButton;           // Button "Back"
    public CanvasGroup overlayCanvas;       // Background dimming (optional)

    private bool isFocusing = false;

    void Start()
    {
        backButton.SetActive(false);

        if (overlayCanvas != null)
            overlayCanvas.alpha = 0;
    }

    void Update()
    {
        if (targetFocus != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetFocus.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetFocus.rotation, Time.deltaTime * moveSpeed);
        }
    }

    public void FocusOnObject(Transform focusPoint)
    {
        targetFocus = focusPoint;
        isFocusing = true;

        backButton.SetActive(true);

        if (overlayCanvas != null)
            overlayCanvas.alpha = 1;

        // Here you can disable colliders on other objects or block input
    }

    public void ResetFocus()
    {
        targetFocus = defaultPosition;
        isFocusing = false;

        backButton.SetActive(false);

        if (overlayCanvas != null)
            overlayCanvas.alpha = 0;

        // Here you can re-enable everything else.
    }
}
