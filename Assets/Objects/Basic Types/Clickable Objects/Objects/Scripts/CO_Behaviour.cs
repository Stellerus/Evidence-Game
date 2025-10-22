using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PolygonCollider2D))]
public class CO_Behaviour : MonoBehaviour, IClickable
{
    //[field: SerializeField] public BaseAction_SO actionEvent { get; set; }
    [field: SerializeField] public UnityEvent actionEvent { get; set; }

    private PolygonCollider2D polygonCollider;
    
    private void Awake()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }


    public void OnClick()
    {
        actionEvent.Invoke();
        Debug.Log($"Event {actionEvent} happens, shit too");
    }

    void Start()
    {
        OnClick();
    }
}
