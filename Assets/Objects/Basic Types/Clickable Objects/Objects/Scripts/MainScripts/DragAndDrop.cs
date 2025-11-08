using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    Vector3 startPosition;
    Collider2D collider2d;

    public string destinationTag = "DropArea";
    public float returnSpeed = 5f;
    public bool returnIfNotDropped = true;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        startPosition = transform.position;
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection);


        if (hitInfo.collider != null && hitInfo.transform.CompareTag(destinationTag))
        {
            transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);
        }
        else if (returnIfNotDropped)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothReturn(startPosition));
        }

        collider2d.enabled = true;
    }

    IEnumerator SmoothReturn(Vector3 targetPos)
    {
        Vector3 startPos = transform.position;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * returnSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        transform.position = targetPos;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
