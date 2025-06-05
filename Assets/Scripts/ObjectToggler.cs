using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
        // Array of objects that will be enabled/disabled
    public GameObject[] objectsToToggle;
    public bool changeBackActive = true; // Whether the objects should be active at the start

    // This method is called when the user clicks the Collider of this GameObject with the mouse
    void OnMouseDown()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null) // Check that the object is assigned in the array
            {
                obj.SetActive(true); // Activate the object
            }
        }
    }

    // The Update method is called every frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && changeBackActive)
        {
            // Disable each object in the array
            foreach (GameObject obj in objectsToToggle)
            {
                if (obj != null) // Check that the object is assigned in the array
                {
                    obj.SetActive(false); // Deactivate the object
                }
            }
        }
    }
}
