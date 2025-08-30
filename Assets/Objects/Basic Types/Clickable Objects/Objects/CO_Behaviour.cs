using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PolygonCollider2D))]
public class CO_Behaviour : MonoBehaviour, IClickable
{
    [field: SerializeField] public BaseAction_SO actionEvent { get; set; }

    private PolygonCollider2D polygonCollider;
    
    private void Awake()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

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
