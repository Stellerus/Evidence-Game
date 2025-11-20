using UnityEngine;
using UnityEngine.Events;

public class PhoneDiskBehaviour : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Quaternion startRotation;

    bool rotateBack = false;
    bool lockDigit = false;
    bool lockPhone = false;

    public char currentDigit;
    public UnityEvent<char> transferDigit;

    float axis = 0;

    private void Awake()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            lockPhone = false;
            if (lockDigit)
                StartRotateBack();
        }


        if (rotateBack)
        {
            float currentZ = transform.eulerAngles.z;
            float destinationZ = startRotation.eulerAngles.z;
            float angleDiff = Mathf.DeltaAngle(currentZ, destinationZ);

            if (Mathf.Abs(angleDiff) <= 3f)
            {
                transform.rotation = startRotation;
                rotateBack = false;
                lockDigit = false;
            }
            else
            {
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * 100 * Time.deltaTime, Vector3.forward);
                lockPhone = true;
            }

            return;
        }

        if (lockDigit && !lockPhone && Input.GetMouseButton(0))
        {
            axis = Input.GetAxis("Mouse X");

            if (axis > 0)
            {
                lockDigit = true;
                DiskDrag();
            }
        }
    }

    private void DiskDrag()
    {
        transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * axis);
    }

    private void OnMouseDown()
    {

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
