using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Camera mainCamera;

    void Awake()
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

        if (hit is null)
        {
            Debug.Log("No Object");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GetButton 1 works");
            hit.gameObject.GetComponent<IClickable>().OnClick();
        }
    }
}
