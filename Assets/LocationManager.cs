using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public Camera cam;

    [Header("Drag Transforms of locations here")]
    [SerializeField] Transform Cabinet;
    [SerializeField] Transform Archive;
    public bool FirstTimeArchive;
    [SerializeField] Transform Interrogation;
    [SerializeField] Transform Hallway;
    [SerializeField] Transform UnzoomFromPhone;
    [SerializeField] Transform UnzoomFromMap;
    [SerializeField] Transform Table;


    private void Awake()
    {
        cam = Camera.main;
        //FindLocations();
    }

    //private void FindLocations() //debug
    //{
    //    Cabinet = GameObject.Find("Cabinet Location").transform;
    //    Archive = GameObject.Find("Archive Location").transform;
    //    Interrogation = GameObject.Find("Interrogation Location").transform;

    //    Hallway = GameObject.Find("Hallway Location").transform;
    //}

    void MoveTo(Transform location)
    {
        if (location != null)
        {
            cam.transform.position = (Vector3)location.position;
        }
    }

    bool isZoomed = false;

    public void MoveToCabinet()
    {
        cam.transform.position = Cabinet.position;
    }

    public void MoveToPhone()
    {
        cam.transform.position = UnzoomFromPhone.position;
        isZoomed = true;
    }

    public void MoveToMap()
    {
        cam.transform.position = UnzoomFromMap.position;
        isZoomed = true;
    }

    public void MoveToArchive()
    {
        //cam.transform.position = Archive.position;
        MoveTo(Archive);
    }

    public void MoveToInterrogation()
    {
        cam.transform.position = Interrogation.position;
    }

    public void MoveToHallway()
    {
        cam.transform.position = Hallway.position;
    }

    public void MoveToTable()
    {
        cam.transform.position = Table.position;
    }

    //private void Update()
    //{
    //    TestLocationChangeOnArrows();
    //}

    //private void TestLocationChangeOnArrows()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        MoveToHallway();
    //    }
    //    if(Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        MoveToInterrogation();
    //    }
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        MoveToCabinet();
    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        MoveToArchive();
    //    }
    //}
}
