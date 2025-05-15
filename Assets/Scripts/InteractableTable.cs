using UnityEngine;

public class InteractableTable : MonoBehaviour
{
    public Transform focusPoint;  // Точка, куда камера будет приближаться

    private void OnMouseDown()
    {
        CameraFocus cameraFocus = Camera.main.GetComponent<CameraFocus>();
        if (cameraFocus != null && focusPoint != null)
        {
            cameraFocus.FocusOnObject(focusPoint);
        }
        else
        {
            Debug.LogWarning("CameraFocus не найден или focusPoint не задан.");
        }
    }
}
