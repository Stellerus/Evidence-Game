using UnityEngine;
using UnityEngine.Events;

public class UnzoomFromPhone : MonoBehaviour
{

    public UnityEvent ZoomBackToOffice; 
    void Start()
    {

    }

    void Update()
    {
        CheckEscape();
    }

    public void CheckEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           ZoomBackToOffice.Invoke();
        }
    }
}