using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenuAttribute( fileName = "BaseAction", menuName = "Action"),]
public class BaseAction_SO : ScriptableObject
{
    public UnityEvent Action;
}
