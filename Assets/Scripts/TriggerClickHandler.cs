using UnityEngine;

public class TriggerClickHandler : MonoBehaviour
{
    public string targetTag = "Player";

    private bool isPlayerInTrigger = false;
    private Collider2D playerCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Player вошёл в триггер!");
            isPlayerInTrigger = true;
            playerCollider = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Player вышел из триггера!");
            isPlayerInTrigger = false;
            playerCollider = null;
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse position is within the bounds of the player's collider
            if (playerCollider != null && playerCollider.OverlapPoint(mouseWorldPos))
            {
                HandleAction(playerCollider);
            }
        }
    }

    private void HandleAction(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} was clicked inside trigger!");
    }
}

