using UnityEngine;
using UnityEngine.Events;

public class PhoneDiskBehaviour : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Quaternion startRotation;
    bool rotateBack = false;

    bool lockDigit = false;

    public char currentDigit;
    public UnityEvent<char> transferDigit;

    float axis = 0;

    private void Awake()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        //if (rotateBack)
        //{
        //    if (transform.rotation == startRotation)
        //    {
        //        rotateBack = false;
        //    }
        //    //transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotationSpeed * 2);
        //    transform.rotation *= Quaternion.AngleAxis(rotationSpeed * 2, Vector3.forward);


        //}


        if (rotateBack)
        {
            float currentZ = transform.eulerAngles.z;
            float destinationZ = startRotation.eulerAngles.z;
            float angleDiff = Mathf.DeltaAngle(currentZ, destinationZ);

            if (Mathf.Abs(angleDiff) <= 3f) // threshold to stop rotation
            {
                transform.rotation = startRotation;
                rotateBack = false;
            }
            else
            {
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * 100 * Time.deltaTime, Vector3.forward);
            }
        }


        if (!rotateBack && lockDigit)
        {
            axis = Input.GetAxis("Mouse X");

            //Debug.Log(axis);

            if (!rotateBack && axis > 0)
            {
                DiskDrag();
            }
        }
        
    }
    private void DiskDrag()
    {
        //transform.rotation = new Quaternion(0, 0, transform.rotation.z - rotationSpeed * axis * Mathf.Deg2Rad, 0);
        transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * axis);
    }


    private void OnMouseDrag()
    {
        //axis = Input.GetAxis("Mouse X");

        ////Debug.Log(axis);

        //if (axis > 0 && !rotateBack)
        //{
        //    rotateBack = false;

        //    DiskDrag();
        //}
        
    }


    private void OnMouseUp()
    {
        rotateBack = true;
    }

    public void LockDigit()
    {
        lockDigit = true;
    }
    public void UnlockDigit()
    {
        lockDigit = false;
    }

    public char GetCurrentDigit()
    {
        return currentDigit;
    }
    public void SetCurrentDigit(char digit)
    {
        currentDigit = digit;
        transferDigit.Invoke(digit);

    }
    public void StartRotateBack()
    {
        rotateBack = true;
    }
}
