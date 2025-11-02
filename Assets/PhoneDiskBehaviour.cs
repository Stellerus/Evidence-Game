using UnityEngine;

public class PhoneDiskBehaviour : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Quaternion startRotation;
    bool rotateBack = false;

    private void Awake()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (rotateBack)
        {
            if (transform.rotation == startRotation)
            {
                rotateBack = false;
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotationSpeed * 2);
        }
    }

    private void OnMouseDrag()
    {
        float axis = Input.GetAxis("Mouse X");

        Debug.Log(axis);
        //if (axis <=0)
        //{
        //    return;
        //}
        if (axis > 0 && !rotateBack)
        {
            rotateBack = false;
            //transform.rotation = new Quaternion(0, 0, transform.rotation.z - rotationSpeed * axis * Mathf.Deg2Rad, 0);
            transform.eulerAngles -= new Vector3(0,0, rotationSpeed * axis);
        }
        
    }

    private void OnMouseUp()
    {
        rotateBack = true;
    }
}
