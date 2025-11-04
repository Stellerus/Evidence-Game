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

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (isLocked) return;

    //    CrimePointBehaviour crime = collision.GetComponent<CrimePointBehaviour>();

    //    if (crime != null)
    //    {
    //        transform.position = Vector3.Lerp(
    //            transform.position,
    //            crime.transform.position,
    //            Time.deltaTime * magnetSpeed
    //        );
    //    }
    //}

    public void LockMovement()
    {
        isLocked = true;
    }





    private void OnTriggerStay2D(Collider2D collision)
    {
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
        if (attachedCrimePoint == null && attachedCrimePoint != newCrime)
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