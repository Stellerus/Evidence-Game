using UnityEngine;

public class ShowOnHover : MonoBehaviour
{
    public GameObject objectToShow;

    void Start()
    {
        objectToShow.SetActive(false);
    }

    void OnMouseEnter()
    {
        objectToShow.SetActive(true);
    }

    void OnMouseExit()
    {
        objectToShow.SetActive(false);
    }
}

