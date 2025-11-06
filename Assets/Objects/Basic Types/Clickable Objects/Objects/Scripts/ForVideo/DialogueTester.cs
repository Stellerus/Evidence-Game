using UnityEngine;
using UnityEngine.Events;

public class DialogueTester : MonoBehaviour
{
    [SerializeField] public UnityEvent testEvent;

    private void Start()
    {
        testEvent.Invoke();
    }
}
