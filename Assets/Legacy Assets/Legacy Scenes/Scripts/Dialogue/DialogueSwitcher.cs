using UnityEngine.Events;
using UnityEngine;

public class DialogueSwitch : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent TurnedOn;
    public UnityEvent TurnedOff;

    void TurnOn()
    {
        TurnedOn.Invoke();
    }

    void TurnOff()
    {
        TurnedOff.Invoke();
    }
}