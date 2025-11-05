using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapToDesk : MonoBehaviour
{

    public MapBehaviour mapBehaviour;
    public FolderButton2D tableBehaviour;

    public void GetDocumentsToTable()
    {
        GetDocuments(mapBehaviour.GetActiveCrimePoints(), tableBehaviour.sheetPrefabs);
    }
    public List<GameObject> GetDocuments(List<CrimePointBehaviour> crimePoints, List<GameObject> documents)
    {

        foreach (CrimePointBehaviour point in crimePoints)
        {
            if (point is not null && !documents.Contains(point.gameObject))
            {
                documents.Add(point.gameObject);
            }

        }


        return documents;
    }
}
