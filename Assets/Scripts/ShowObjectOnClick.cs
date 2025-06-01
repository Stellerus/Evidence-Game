using UnityEngine;

public class ShowOnClick : MonoBehaviour
{
    public GameObject objectToShow;
    private bool isShown = false;

    void Start()
    {
        objectToShow.SetActive(false);
    }

    void OnMouseDown()
    {
        isShown = !isShown;
        objectToShow.SetActive(isShown);
    }
}
