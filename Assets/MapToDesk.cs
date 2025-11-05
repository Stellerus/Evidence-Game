using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapToDesk : MonoBehaviour
{

    MapBehaviour mapBehaviour;
    // Insert Desk Folder Script

    public List<GameObject> GetDocuments(List<CrimePointBehaviour> crimePoints, List<GameObject> documents)
    {

        foreach (CrimePointBehaviour point in crimePoints)
        {
            //if (point@@ is not null && !documents.Contains(point))
            //{
            //    documents.Add(point@@);
            //}

        }


        return documents;
    }
}
