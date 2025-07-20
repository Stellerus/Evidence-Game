using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Objects.Archive
{
    internal class EvidenceComparer : IComparer<EvidenceBehaviour>
    {
        public int Compare(EvidenceBehaviour one, EvidenceBehaviour two)
        {
            return CompareByString(one, two) + CompareByRelevance(one, two);
        }


        /// <summary>
        /// This will not work (change to one method that compares using both params. 
        /// If needs another sort implement another Icomparer or switch methods internally
        /// 
        /// </summary>
        public int CompareByString(EvidenceBehaviour one, EvidenceBehaviour two)
        {
            if (string.Compare(one.evidenceData.textData.Name, two.evidenceData.textData.Name, StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                return string.Compare(one.evidenceData.textData.Name, one.evidenceData.textData.Name, StringComparison.CurrentCultureIgnoreCase);
            }
            else
            {
                return 0;
            }
        }

        public int CompareByRelevance(EvidenceBehaviour one, EvidenceBehaviour two)
        {
            if (one.relevance.CompareTo(two.relevance) != 0)
            {
                return one.relevance.CompareTo(two.relevance);
            }
            else
            {
                return 0;
            }
        }
    }
}
