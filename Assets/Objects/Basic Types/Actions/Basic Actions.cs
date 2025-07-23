using System;
using UnityEngine;

public static class BasicActions
{
    public static Action DebugActionTest = () =>
    {
        Debug.LogError($"Debug Action test successfull");
    };

}
