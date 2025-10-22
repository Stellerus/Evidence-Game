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

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void CountDown()
    {
        if (crimePoints != null) {
            mapCount.Decrease();
            
            }
        }

    public void SpawnPolice()
    {
        for (int i = 0; i < mapCount.currentCount; i++)
        {
            PoliceBehaviour policeSpawn = Instantiate(policeSpawnOriginal,transformPolice).GetComponent<PoliceBehaviour>();
        }
        return;

        //foreach (var Police in policeBehaviour)
        //{

        //}
    }
}