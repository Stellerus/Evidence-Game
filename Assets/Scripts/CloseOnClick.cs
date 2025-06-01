using UnityEngine;

public class HideOnClickOutside : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Если Raycast не попал в этот объект — выключаем его
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != gameObject)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                // Если клик по пустому месту — тоже выключаем
                gameObject.SetActive(false);
            }
        }
    }
}

