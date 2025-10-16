using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class PhoneBehaviour : MonoBehaviour
{
    [SerializeField] GameObject phoneDisk;
    [SerializeField] GameObject phoneCounter;

    [SerializeField] List<CircleCollider2D> digits;

    public float blockDiskDegree;

    private void Awake()
    {
        Initialize();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, phoneCounter.transform.position);
    }


    private void Initialize()
    {
        foreach (Transform children in transform)
        {
            InitializeDisk(children);

            InitializeCounter(children);
        }
    }

    void InitializeDisk(Transform children)
    {
        if (children.name == "Disc")
        {
            phoneDisk = children.gameObject;
            foreach (Transform diskChild in children.transform)
            {
                digits.Add(diskChild.gameObject.GetComponent<CircleCollider2D>());
            }
        }
    }

    void InitializeCounter(Transform children)
    {
        if (children.name == "CounterAxis")
        {
            blockDiskDegree = children.transform.localEulerAngles.z;
            Debug.Log(children.transform.rotation.z);
            foreach (Transform counterChild in children.transform)
            {
                phoneCounter = counterChild.gameObject;
            }
        }
    }


    private void Reset()
    {
        Initialize();
    }
}
