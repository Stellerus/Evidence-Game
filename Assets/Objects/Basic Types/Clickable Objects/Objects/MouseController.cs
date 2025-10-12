using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z)
        );
        mousePos.z = 0f;

        transform.position = mousePos;

        Collider2D hit = Physics2D.OverlapPoint(mousePos);

       
    }
}
