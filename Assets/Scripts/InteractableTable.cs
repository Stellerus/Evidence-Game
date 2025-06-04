using UnityEngine;

public class InteractableTable : MonoBehaviour
{
    public Transform focusPoint;  // The point the camera will zoom in to

    private void OnMouseDown()
    {
        CameraFocus cameraFocus = Camera.main.GetComponent<CameraFocus>();
        if (cameraFocus != null && focusPoint != null)
        {
            cameraFocus.FocusOnObject(focusPoint);
        }
        else
        {
            Debug.LogWarning("CameraFocus not found or focusPoint not set.");
        }
    }
}
