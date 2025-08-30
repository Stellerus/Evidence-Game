using System;
using UnityEngine;
using UnityEngine.Events;

public interface IClickable
{
    public BaseAction_SO actionEvent { get; set; }

    void OnClick();
}
