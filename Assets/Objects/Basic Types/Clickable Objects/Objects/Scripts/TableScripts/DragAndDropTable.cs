using UnityEngine;
using System.Collections;

public class DragAndDropTable : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropAreaTable";
    public float returnSpeed = 5f;

    [HideInInspector] public Transform originStack;
    [HideInInspector] public Vector3 originLocalOffset;

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        Debug.Log("Ti dyrak");
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;

        Collider2D hitInfo = Physics2D.OverlapPoint(MouseWorldPosition());

        if (hitInfo != null && hitInfo.CompareTag(destinationTag))
        {
            transform.position = MouseWorldPosition();
        }
        else
        {
            if (originStack != null)
            {
                StopAllCoroutines();
                StartCoroutine(SmoothReturn(originStack.position + originLocalOffset));
            }
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
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
