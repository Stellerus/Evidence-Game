using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CallPersonEvent : UnityEvent<int> { }

public class InputEventManager : MonoBehaviour
{
    [Header("Event Settings")]
    public CallPersonEvent CallPerson;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CallPerson?.Invoke(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            CallPerson?.Invoke(2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            CallPerson?.Invoke(3);
    }
}
