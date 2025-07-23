using System;
using UnityEngine;

public interface IClickable
{
    public Action ClickAction { get; set; }

    public void OnClick();


    public void OnClick(Action outerClickAction);
}
