using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenuAttribute(fileName = "Advanced Action", menuName = "Advanced Action"),]
public class AdvancedAction_SO : ScriptableObject
{
    public UnityEvent[] Action;
}

public class ActionSettings
{

}

public enum ParamSettings
{
    None,
    ChangePosition,

}
