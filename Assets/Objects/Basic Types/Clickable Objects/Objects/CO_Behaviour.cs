using System;
using UnityEngine;
using UnityEngine.Events;

public class CO_Behaviour : MonoBehaviour, IClickable
{
    [field: SerializeField] public BaseAction_SO actionEvent { get; set; }

    public void OnClick()
    {
        actionEvent.Action.Invoke();
        Debug.Log($"Event {actionEvent.name} happens, shit too");
    }

    void Start()
    {
        OnClick();
    }

}
