using UnityEngine;

public class TriggerClickHandler : MonoBehaviour
{
    // Here you can insert wanted tag (for example, "Player")
    public string targetTag = "Player";

    private void OnTriggerStay2D(Collider2D other)
    {
        // Checking if it's the right object
        if (other.CompareTag(targetTag))
        {
            // Handling mouse click
            if (Input.GetKeyDown(KeyCode.H))
            {
                HandleAction(other);
            }
        }
    }

    private void HandleAction(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} was clicked!");
        
    }
}

