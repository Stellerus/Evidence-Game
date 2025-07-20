using UnityEngine;
using UnityEngine.Events;

public class MouseObjController : MonoBehaviour
{
    public UnityEvent OnMouseObjTrigger;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Move the object to the mouse position
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            transform.position = mouseWorldPos;

            // If the object was invisible, make it visible
            if (!GetComponent<SpriteRenderer>().enabled)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("MouseObj is within object: " + other.gameObject.name);

            OnMouseObjTrigger?.Invoke();

            // Make the object invisible and disable the collider
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

