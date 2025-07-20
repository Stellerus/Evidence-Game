using UnityEngine;

public class IL : MonoBehaviour
{
    // Array of objects that will be enabled/disabled
    public GameObject[] objectsToToggle;
    public bool changeBackActive = true; // Whether the objects should be active at the start
    
    public int scenario = 0;
    void OnMouseDown()
    {
        switch(scenario)
        {
            case 0:
                foreach (GameObject obj in objectsToToggle)
                {
                    if (obj != null) // Check that the object is assigned in the array
                    {
                        obj.SetActive(true); // Activate the object
                    }
                }
                scenario = 1; // Change scenario to prevent reactivation
                break;
            case 2:
                foreach (GameObject obj in objectsToToggle)
                {
                    if (obj != null) // Check that the object is assigned in the array
                    {
                        obj.SetActive(true); // Activate the object
                    }
                }
                break;
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

