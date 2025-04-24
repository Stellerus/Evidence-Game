using Assets.Objects.Archive.Evidence;
using UnityEngine;

[RequireComponent (typeof (EvidenceTextData) )]
[CreateAssetMenu(fileName = "EvidenceSO", menuName = "EvidenceSO")]
public class Evidence_SO : ScriptableObject
{
    public EvidenceTextData textData;

    [SerializeField] string evidenceNameInput;
    [SerializeField] string evidenceDescriptionInput;
    [SerializeField] string evidenceTypeInput;

    private void Awake()
    {
        textData = new EvidenceTextData(evidenceNameInput,evidenceDescriptionInput,evidenceTypeInput);
    }

    private void Reset()
    {
        textData = new EvidenceTextData();
    }
}
