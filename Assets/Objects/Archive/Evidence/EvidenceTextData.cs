using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Objects.Archive.Evidence
{
    public class EvidenceTextData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EvidenceType { get; set; }

        public EvidenceTextData(string name, string description, string evidenceType)
        {
            Name = name;
            Description = description;
            EvidenceType = evidenceType;
        }

        public EvidenceTextData()
        {
            Name = "Missing name";
            Description = "Missing description";
            EvidenceType = "Missing Type";

            Debug.LogError($"Warning: {Name}");
            Debug.LogError($"Warning: {Description}");
            Debug.LogError($"Warning: {EvidenceType}");
            
        }
    }
}
