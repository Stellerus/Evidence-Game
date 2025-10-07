using UnityEngine;
using UnityEngine.Events;

public class DoorBehaviour : MonoBehaviour, IClickable
{
    //[field: SerializeField] public BaseAction_SO actionEvent { get; set; }
    [field: SerializeField] public UnityEvent actionEvent { get; set; }

    public void OnClick()
    {
        Debug.Log("IMBA");
        actionEvent.Invoke();
    }

    private void Awake()
    {
        if (actionEvent == null)
        {
            Debug.Log($"Event missing in {this.gameObject.name}");
        }
    }

    void Update()
    {
        
    }
}
