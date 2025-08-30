using System;
using UnityEngine;

interface IClickable_LEGACY
{
    Action ClickAction { get; set; }

    void OnClick();


    void OnClick(Action outerClickAction);
}
