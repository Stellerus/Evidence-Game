using UnityEngine;
using UnityEngine.UI;

public class CameraFocus : MonoBehaviour
{
    public Transform defaultPosition;       // Исходное положение камеры
    public float moveSpeed = 2f;            // Скорость перемещения камеры
    private Transform targetFocus;          // Текущая цель камеры

    public GameObject backButton;           // Кнопка "Назад"
    public CanvasGroup overlayCanvas;       // Затемнение фона (опционально)

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

        // Тут можно отключить коллайдеры у остальных объектов или заблокировать ввод
    }

    public void ResetFocus()
    {
        targetFocus = defaultPosition;
        isFocusing = false;

        backButton.SetActive(false);

        if (overlayCanvas != null)
            overlayCanvas.alpha = 0;

        // Тут можно включить обратно всё остальное
    }
}
