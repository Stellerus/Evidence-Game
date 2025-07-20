using UnityEngine;

public class CourtClick : MonoBehaviour
{
    [SerializeField] private Court Court;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseDown()
    {
        Court.StartCoroutine(Court.DelayedAction(2f, () => { Debug.Log("Done!"); }));
    }
}
