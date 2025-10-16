using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
    CircleCollider2D magnetRadius;
    public GameObject clonePrefab;
    public MapCountBehaviour counter;

    public bool isOriginal = true;

    private bool isLocked = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3.Lerp(collision.transform.position, collision.gameObject.transform.position, 0.5f);
}

    void Start()
    {
        magnetRadius = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
    }

    public void LockMovement()
    {
        isLocked = true;
    }
}