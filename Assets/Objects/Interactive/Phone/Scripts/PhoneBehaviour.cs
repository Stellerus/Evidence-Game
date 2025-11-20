using System.Collections.Generic;
using UnityEngine;

public class PhoneBehaviour : MonoBehaviour
{
    [SerializeField] GameObject phoneDisk;
    [SerializeField] GameObject phoneCounter;

    //[SerializeField] List<CircleCollider2D> digits;

    public float blockDiskDegree;

    [SerializeField] float degreeShift = 0.58f;
    [SerializeField] float sectorSizeAngle = 25.6f;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        //foreach (Transform children in transform)
        //{
        //    InitializeDisk(children);

        //    InitializeCounter(children);
        //}
    }

    //void InitializeDisk(Transform children)
    //{
    //    if (children.name == "Disc")
    //    {
    //        phoneDisk = children.gameObject;
    //        foreach (Transform diskChild in children.transform)
    //        {
    //            digits.Add(diskChild.gameObject.GetComponent<CircleCollider2D>());
    //        }
    //    }
    //}

    //void InitializeCounter(Transform children)
    //{
    //    if (children.name == "CounterAxis")
    //    {
    //        blockDiskDegree = children.transform.localEulerAngles.z;
    //        Debug.Log(children.transform.rotation.z);
    //        foreach (Transform counterChild in children.transform)
    //        {
    //            phoneCounter = counterChild.gameObject;
    //        }
    //    }
    //}


    private void Reset()
    {
        Initialize();
    }



    /// <summary>
    /// ONLY FOR UNITY VISUALISATION
    /// </summary> 

    private void OnDrawGizmos()
    {
        DrawCounterLine();
    }

    private void DrawCounterLine()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, phoneCounter.transform.position);
        Gizmos.color = Color.cyan;
        DrawDiskSectors(sectorSizeAngle, sectorCount: 10, deadzoneSize: 90);
    }

    private void DrawDiskSectors(float sectorSizeAngle, int sectorCount, float deadzoneSize)
    {
        float circleSize = 2 * Mathf.PI; //360 degree in radians
        float radius = Vector3.Distance(phoneDisk.transform.position, phoneCounter.transform.position);

        

        for (int i = 0; i <= sectorCount; i++)
        {
            float currentSectorInRad = i * sectorSizeAngle * Mathf.Deg2Rad;

            // Moves starting point of all sectors by Disk rotation
            float circleRotationCorrection = (circleSize + phoneDisk.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

            float currentSector = (degreeShift * deadzoneSize * Mathf.Deg2Rad);

            float sectorBorderDegree = circleRotationCorrection - currentSector - currentSectorInRad; // calculate the step in degrees

            // X and Y of a border Point
            float pointX = phoneDisk.transform.position.x + radius * Mathf.Cos(sectorBorderDegree);
            float pointY = phoneDisk.transform.position.y + radius * Mathf.Sin(sectorBorderDegree);

            Gizmos.DrawLine(phoneDisk.transform.position, new Vector3(pointX, pointY));
        }
    }

}
