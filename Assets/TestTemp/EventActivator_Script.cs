using UnityEngine;
using UnityEngine.Events;

public class EventActivator_Script : MonoBehaviour
{
    public UnityEvent blueEvent;

    public GameObject blueGameObject;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            //blueGameObject.GetComponent<SpriteRenderer>().color = Color.green;
            blueGameObject.GetComponent<EventInvokeTest_Script>().TestMethodPidaras();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            blueEvent.Invoke();
        }
    }
}
