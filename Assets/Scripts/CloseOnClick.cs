using UnityEngine;

public class HideOnClickOutside : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the Raycast didn't hit this object – disable it
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != gameObject)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                // If the click is on an empty spot – disable it as well
                gameObject.SetActive(false);
            }
        }
    }
}

