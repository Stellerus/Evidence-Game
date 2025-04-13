using UnityEngine;

public class Evidence : MonoBehaviour
{
    public TextMesh evidenceName;
    [SerializeField] string evidenceNameInput;

    public TextMesh evidenceDescription;
    [SerializeField] string evidenceDescriptionInput;

    public TextMesh evidenceType;
    [SerializeField] string evidenceTypeInput;

    
    [SerializeField]
    [Range(0,8)]public byte relevance;

    public bool inUse = false;


    void Awake()
    {
        
    }

}
