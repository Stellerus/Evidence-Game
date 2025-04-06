using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    private int lastScreenWidth;
    private int lastScreenHeight;

    void Start()
    {
        AdjustCameraSize();
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;
    }

    void Update()
    {
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            AdjustCameraSize();
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
        }
    }

    void AdjustCameraSize()
    {
        Camera cam = Camera.main;
        if (cam.orthographic)
        {
            float aspectRatio = (float)Screen.width / Screen.height;
            cam.orthographicSize = 5f / aspectRatio;  // 5f Ч базовый размер, можно изменить
        }
    }
}

