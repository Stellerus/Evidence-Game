using UnityEngine;

public class ObjectOffOnClick : MonoBehaviour
{
    public GameObject CameraToOff;
    public GameObject CameraToOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseDown()
    {
            if (CameraToOff != null) // Check that the object is assigned in the array
            {
                CameraToOff.SetActive(false); // Activate the object
            }

            if (CameraToOn != null) // Check that the object is assigned in the array
            {
                CameraToOn.SetActive(true); // Deactivate the object
            }
    }
}
