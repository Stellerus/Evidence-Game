using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = FindFirstObjectByType<Camera>();
    }

    public void LocationChange(Component component, object position)
    {
        cam.transform.position = (Vector3)position;
    }
}
