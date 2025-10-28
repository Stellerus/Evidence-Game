using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 pos;
    [SerializeField]

    Camera cam;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void LocationChange(Component component, object position)
    {
        cam.transform.position = (Vector3)position;
    }
}
