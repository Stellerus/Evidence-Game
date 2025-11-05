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
    public List<GameObject> GetDocuments(List<CrimePointBehaviour> crimePoints, List<GameObject> docs)
    {

        foreach (CrimePointBehaviour point in crimePoints)
        {
            if (point is not null)
            {
                foreach(GameObject document in point.documents)
                {
                    if (!docs.Contains(document))
                    {
                        docs.Add(document);
                    }
                }
            }

        }


        return docs;
    }
}
