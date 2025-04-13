using Assets.Objects.Archive;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Archive : MonoBehaviour
{
    List<Evidence> allEvidences = new(); 
    List<Evidence> currentEvidenses = new();

    void Awake()
    {
        InitializeArchive();
    }




    void InitializeArchive()
    {
        EvidenceComparer comparer = new EvidenceComparer();

        //Change this if evidences are in different object
        allEvidences = FindObjectsByType<Evidence>(FindObjectsSortMode.None).ToList();

        SortEvidence(comparer);

        foreach (var evidence in allEvidences)
        {
            if (evidence.inUse)
            {
                currentEvidenses.Add(evidence);
            }
        }
    }

    private void SortEvidence(EvidenceComparer comparer)
    {
        allEvidences.Sort(comparer);
    }

    public List<Evidence> GetEvidenceByName(string name, List<Evidence> evidences)
    {
        var result = from e in evidences
                     where e.evidenceName.text.ToUpper().Trim() == name.ToUpper().Trim()
                     select e;
        return result.ToList();
    }

    public List<Evidence> GetCurrentEvidences()
    {
        return currentEvidenses;
    }
    public List<Evidence> GetAllEvidences()
    {
        return allEvidences;
    }
}
