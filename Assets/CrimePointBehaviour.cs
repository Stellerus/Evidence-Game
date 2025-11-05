using UnityEngine;

public class CrimePointBehaviour : MonoBehaviour
{
    public bool isOccupied = false;

    public bool CanAttach()
    {
        return !isOccupied;
    }
    public void Occupy()
    {
        isOccupied = true;
    }

    public void Release()
    {
        isOccupied = false;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}