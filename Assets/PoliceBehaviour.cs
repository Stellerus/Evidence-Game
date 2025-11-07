using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
    public CrimePointBehaviour attachedCrimePoint;
    private CircleCollider2D magnetRadius;
    public float magnetSpeed = 2f;

    private bool isLocked = false;

    private void Start()
    {
        magnetRadius = GetComponent<CircleCollider2D>();
    }

    public void LockMovement()
    {
        isLocked = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isLocked || attachedCrimePoint != null)
            return;

        CrimePointBehaviour crime = collision.GetComponent<CrimePointBehaviour>();
        if (crime == null || !crime.CanAttach())
            return;

        float distance = Vector3.Distance(transform.position, crime.transform.position);

        // Притягиваемся к ближайшей точке
        if (distance < magnetRadius.radius) // можно настроить порог
        {
            transform.position = Vector3.Lerp(
                transform.position,
                crime.transform.position,
                Time.deltaTime * magnetSpeed
            );

            if (distance < 0.2f)
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