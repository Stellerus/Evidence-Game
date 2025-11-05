using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CrimePointBehaviour : MonoBehaviour
{
    public CircleCollider2D collision;
    public List<GameObject> documents;
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

    private void Awake()
    {
        collision = GetComponent<CircleCollider2D>();
    }

    public void Deactivate()
    {
        collision.enabled = false;
    }

    public void Activate()
    {
        collision.enabled = true;
    }
}