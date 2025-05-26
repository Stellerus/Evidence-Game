using UnityEngine;
using UnityEngine.Events;

public class TriggerClickHandler : MonoBehaviour
{
    public string targetTag = "Player";

    [Header("Event when clicking on an object in a trigger")]
    public UnityEvent onClickInTrigger;

    private bool isPlayerInTrigger = false;
    private Collider2D playerCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isPlayerInTrigger = true;
            playerCollider = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
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
        onClickInTrigger.Invoke(); // Invoke the UnityEvent when the player clicks while inside the trigger
    }
}

