using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
    public CrimePointBehaviour attachedCrimePoint;
    private CircleCollider2D magnetRadius;
    public float magnetSpeed = 2f;

    private bool isLocked = false;
    private bool isBeingDragged = false;
    private Camera mainCamera;

    private void Start()
    {
        magnetRadius = GetComponent<CircleCollider2D>();
        mainCamera = Camera.main;
    }

    public void LockMovement()
    {
        isLocked = true;
    }

    private void Update()
    {
        HandleDrag();
    }

    private void HandleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos);

            if (hit != null && hit.gameObject == gameObject)
            {

                isBeingDragged = !isBeingDragged;

                if (isBeingDragged)
                {

                    if (attachedCrimePoint != null)
                    {
                        attachedCrimePoint.Release();
                        attachedCrimePoint = null;
                    }
                }
            }
        }

        if (isBeingDragged)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isBeingDragged || isLocked) return;

        CrimePointBehaviour crime = collision.GetComponent<CrimePointBehaviour>();
        if (crime == null) return;

        if (!crime.CanAttach()) return;

        transform.position = Vector3.Lerp(
            transform.position,
            crime.transform.position,
            Time.deltaTime * magnetSpeed
        );

        float distance = Vector3.Distance(transform.position, crime.transform.position);
        if (distance < 0.2f)
        {
            if (crime != null)
            {
                AttachToCrimePoint(crime);
            }
        }
    }

    private void AttachToCrimePoint(CrimePointBehaviour newCrime)
    {
        if (attachedCrimePoint != null && attachedCrimePoint != newCrime)
        {
            attachedCrimePoint.Release();
        }

        attachedCrimePoint = newCrime;
        attachedCrimePoint.Occupy();

        transform.position = attachedCrimePoint.transform.position;
    }

    private void OnDestroy()
    {
        if (attachedCrimePoint != null)
        {
            attachedCrimePoint.Release();
        }
    }
}