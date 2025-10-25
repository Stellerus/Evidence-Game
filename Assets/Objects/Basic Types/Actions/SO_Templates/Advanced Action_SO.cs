using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenuAttribute(fileName = "Advanced Action", menuName = "Advanced Action"),]
public class AdvancedAction_SO : ScriptableObject
{
    public ParamSettings ParamSettings;
    public UnityEvent<object> objAction;

    private void OnValidate()
    {

    }


}

[Serializable]
public class ActionSettings : MonoBehaviour
{
    
}

public enum ParamSettings
{
    None,
    ChangePosition,

}
