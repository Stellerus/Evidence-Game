using Assets.Objects.Archive.Evidence;
using UnityEngine;

[RequireComponent(typeof(Evidence_SO))]
[CreateAssetMenu(fileName = "EvidenceObject", menuName = "Evidence")]
public class EvidenceBehaviour : MonoBehaviour
{
    [Space(10f)]
    [Header("Main Script for evidence")]
    public Evidence_SO evidenceData;

    [SerializeField]
    [Tooltip("Sets how much relevant is Evidence to current episode")]
    [Range(0,8)]public byte relevance;

    [Tooltip("Sets if this Evidence is used in current episode")]
    public bool inUse { get; set; } = false;


    void Awake()
    {
        evidenceData = gameObject.GetComponent<Evidence_SO>();
    }

}
