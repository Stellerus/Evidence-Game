using JetBrains.Annotations;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapBehaviour : MonoBehaviour
{


    public List<CrimePointBehaviour> crimePoints;

    public MapCountBehaviour mapCount;

    public List<PoliceBehaviour> policeBehaviour;
    public GameObject policeSpawnOriginal;
    public Transform transformPolice;
    public GameObject clonePrefab;
    public List<PoliceSpawnpointBehaviour> policeSpawnpoints;

    private List<bool> spawnpointOccupied = new List<bool>();


    void Awake()
    {
        for (int x = 0; x < mapCount.currentCount; x++)
        {
            SpawnPolice();
        }

    }

    void Start()
    {

    }


    void Update()
    {

    }


    //public void CountDown()
    //{
    //    if (crimePoints != null) {
    //        mapCount.Decrease();

    //        }
    //    }


    public void SpawnPolice()
    {
        foreach (var spawnpoint in policeSpawnpoints)
        {

            if (!spawnpoint.isOccupied)
            {
                GameObject newPoliceGroup = Instantiate(
                    clonePrefab,
                    spawnpoint.transform.position,
                    spawnpoint.transform.rotation,
                    transformPolice
                );
                spawnpoint.isOccupied = true;
                break;
            }
        }
    }
}