using Assets.Objects.Archive;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Archive : MonoBehaviour
{
    [SerializeField]List<EvidenceBehaviour> allEvidences = new(); 
    List<EvidenceBehaviour> currentEvidenses = new();

    void Awake()
    {
        InitializeArchive();
    }

    private void Reset()
    {
        InitializeArchive();
    }


    void InitializeArchive()
    {
        EvidenceComparer comparer = new EvidenceComparer();

        //Change this if evidences are in different object/scene
        //Warning: Searches whole scene. Not all inspector and not only hierarchy
        //for hierarchy use InitializeCurrent
        allEvidences = FindObjectsByType<EvidenceBehaviour>(FindObjectsSortMode.None).ToList();

        SortEvidence(comparer);

        InitializeCurrent();
    }

    void InitializeCurrent()
    {
        foreach (var evidence in allEvidences)
        {
            if (evidence.inUse)
            {
                currentEvidenses.Add(evidence);
            }
        }
    }
    
    //Can be used as Extension method, or reused if needed
    List<T> GetChildrenComponents<T>()
    {
        List<T> children = new();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject.GetComponent<T>());
        }
        return children;
    }

    private void SortEvidence(EvidenceComparer comparer)
    {
        allEvidences.Sort(comparer);
    }

    public List<EvidenceBehaviour> GetEvidenceByName(string name, List<EvidenceBehaviour> evidences)
    {
        var result = from e in evidences
                     where e.evidenceData.textData.Name.ToUpper().Trim() == name.ToUpper().Trim()
                     select e;
        return result.ToList();
    }

    public List<EvidenceBehaviour> GetCurrentEvidences()
    {
        return currentEvidenses;
    }
    public List<EvidenceBehaviour> GetAllEvidences()
    {
        return allEvidences;
    }
}
