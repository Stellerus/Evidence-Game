using UnityEngine;

public class TriggerClickHandler : MonoBehaviour
{
    // Here you can insert wanted tag (for example, "Player")
    public string targetTag = "Player";

    private void OnTriggerStay(Collider other)
    {
        // Checking if it's the right object
        if (other.CompareTag(targetTag))
        {
            // Handling mouse click
            if (Input.GetMouseButtonDown(0))
            {
                HandleAction(other);
            }
        }
    }

    private void HandleAction(Collider other)
    {
        Debug.Log($"{other.gameObject.name} кликнут внутри триггера!");
        
    }
}

