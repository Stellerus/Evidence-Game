using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragAndDropTable : MonoBehaviour
{
    Vector3 offset;
    Collider2D myCollider;
    Camera mainCam;

    [Header("Drop settings")]
    public string destinationTag = "DropAreaTable";
    public bool returnIfNotDropped = true;

    [Header("Return (smooth)")]
    public bool useSmoothReturn = true;
    public float returnSpeed = 5f;

    [HideInInspector] public Transform originStack;
    [HideInInspector] public Vector3 originLocalOffset;

    Coroutine returnCoroutine;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        mainCam = Camera.main;
        if (mainCam == null) Debug.LogWarning("DragAndDrop: Camera.main is null. MouseWorldPosition may be incorrect.");
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        if (returnCoroutine != null) { StopCoroutine(returnCoroutine); returnCoroutine = null; }
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (myCollider != null) myCollider.enabled = false;

        Vector2 mouseWorld2D = MouseWorldPosition2D();
        Collider2D hit = Physics2D.OverlapPoint(mouseWorld2D);

        bool droppedOnRight = (hit != null && hit.CompareTag(destinationTag));

        if (droppedOnRight)
        {
            Vector3 newPos = CameraToWorldPoint2D(Input.mousePosition);
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
        else
        {
            if (returnIfNotDropped && originStack != null)
            {
                Vector3 targetWorld = originStack.position + originLocalOffset;
                if (useSmoothReturn)
                {
                    if (returnCoroutine != null) StopCoroutine(returnCoroutine);
                    returnCoroutine = StartCoroutine(SmoothReturn(targetWorld));
                }
                else
                {
                    transform.position = targetWorld;
                }
            }
        }

        if (myCollider != null) myCollider.enabled = true;
    }

    IEnumerator SmoothReturn(Vector3 target)
    {
        Vector3 from = transform.position;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * returnSpeed;
            transform.position = Vector3.Lerp(from, target, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
        transform.position = target;
        returnCoroutine = null;
    }

    Vector3 MouseWorldPosition()
    {
        if (mainCam == null) return Vector3.zero;
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = Mathf.Abs(mainCam.transform.position.z - transform.position.z);
        return mainCam.ScreenToWorldPoint(mouseScreen);
    }

    Vector2 MouseWorldPosition2D()
    {
        Vector3 w = MouseWorldPosition();
        return new Vector2(w.x, w.y);
    }

    Vector3 CameraToWorldPoint2D(Vector3 screenPos)
    {
        if (mainCam == null) return Vector3.zero;
        screenPos.z = Mathf.Abs(mainCam.transform.position.z - transform.position.z);
        Vector3 w = mainCam.ScreenToWorldPoint(screenPos);
        return new Vector3(w.x, w.y, transform.position.z);
    }
}
