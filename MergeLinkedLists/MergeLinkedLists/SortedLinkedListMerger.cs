using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeLinkedLists
{
    public class SortedLinkedListMerger : ILinkedListMerger
    {
        public LinkedListNode MergeLists(LinkedListNode l1, LinkedListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            if (l1.Value < l2.Value)
            {
                l1.Next = MergeLists(l1.Next, l2);
                return l1;
            }
            else
            {
                l2.Next = MergeLists(l2.Next, l1);
                return l2;
            }
        }
    }
}
