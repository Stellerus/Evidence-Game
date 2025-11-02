using UnityEngine;

public class EnvegationRoomController : MonoBehaviour
{
    [Header("Suspects")]
    [SerializeField] private GameObject suspect1;
    [SerializeField] private GameObject suspect2;
    [SerializeField] private GameObject suspect3;

    [Header("Room Settings")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject door;

    private void DeactivateAll()
    {
        if (suspect1) suspect1.SetActive(false);
        if (suspect2) suspect2.SetActive(false);
        if (suspect3) suspect3.SetActive(false);
    }

    public void CallPerson(int id)
    {
        DeactivateAll();
        CloseDoor();

        GameObject target = id switch
        {
            1 => suspect1,
            2 => suspect2,
            3 => suspect3,
            _ => null
        };

        if (target == null)
        {
            Debug.LogWarning($"Invalid person ID: {id}");
            return;
        }

        if (spawnPoint != null)
            target.transform.position = spawnPoint.position;

        target.SetActive(true);

        Debug.Log($"Person {id} called into the room.");
    }

    private void CloseDoor()
    {
        if (door != null)
            door.SetActive(true);

        Debug.Log("Door closed.");
    }
}
