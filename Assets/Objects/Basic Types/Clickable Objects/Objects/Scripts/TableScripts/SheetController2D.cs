using UnityEngine;

public class SheetController2D : MonoBehaviour
{
    [HideInInspector] public Transform originStack;
    [HideInInspector] public Vector3 originLocalOffset;

    public void SetOrigin(Transform stack, Vector3 localOffset)
    {
        originStack = stack;
        originLocalOffset = localOffset;
    }
}
