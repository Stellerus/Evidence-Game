using UnityEngine;

public class DigitController : MonoBehaviour
{
    public char digit;
    PhoneDiskBehaviour disk;

    private void Awake()
    {
        disk = GetComponentInParent<PhoneDiskBehaviour>();
    }

    private void OnMouseDown()
    {
        disk.SetCurrentDigit(digit);
        
    }

    private void OnMouseDrag()
    {
        disk.LockDigit();
    }

    private void OnMouseUp()
    {
        disk.UnlockDigit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PhoneCounter" && this.digit == disk.GetCurrentDigit())
        {
            Debug.Log("Collision success");
            disk.StartRotateBack();
        }
    }


}
