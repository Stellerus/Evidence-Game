using System;
using UnityEngine;
using UnityEngine.Events;

public interface IClickable
{
    public UnityEvent actionEvent { get; set; }

    void OnClick();
}
