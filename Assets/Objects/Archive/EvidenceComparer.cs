using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Objects.Archive
{
    internal class EvidenceComparer : IComparer<Evidence>
    {
        public int Compare(Evidence one, Evidence two)
        {
            return CompareByString(one, two) + CompareByRelevance(one, two);
        }

        public int CompareByString(Evidence one, Evidence two)
        {
            if (string.Compare(one.evidenceName.text, two.evidenceName.text, StringComparison.CurrentCultureIgnoreCase) != 0)
            {
                return string.Compare(one.evidenceName.text, two.evidenceName.text, StringComparison.CurrentCultureIgnoreCase);
            }
            else
            {
                return 0;
            }
        }

        public int CompareByRelevance(Evidence one, Evidence two)
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
