using System;
using UnityEngine;

public class CO_TestBehaviour : MonoBehaviour, IClickable
{
    Action IClickable.ClickAction { get; set; }

    public void OnClick()
    {
        throw new NotImplementedException();
    }

    public void OnClick(Action clickAction)
    {
        clickAction.Invoke();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnClick(BasicActions.DebugActionTest);
        }
    }
}
