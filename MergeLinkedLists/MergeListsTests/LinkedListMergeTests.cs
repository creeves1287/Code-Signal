using System;
using MergeLinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeListsTests
{
    [TestClass]
    public class LinkedListMergeTests
    {
        [TestMethod]
        public void LinkedListMergerTests()
        {
            ILinkedListMerger linkedListMerger = new SortedLinkedListMerger();
            RunTests(linkedListMerger);
        }

        private void RunTests(ILinkedListMerger linkedListMerger)
        {
            TwoNullTest(linkedListMerger);
            OneNullTest(linkedListMerger);
            MergeTest(linkedListMerger);
        }

        private void TwoNullTest(ILinkedListMerger linkedListMerger)
        {
            LinkedListNode l1 = null;
            LinkedListNode l2 = null;
            LinkedListNode result = linkedListMerger.MergeLists(l1, l2);
            Assert.IsNull(result);
        }

        private void OneNullTest(ILinkedListMerger linkedListMerger)
        {
            LinkedListNode l1 = null;
            int[] a2 = new int[] { 2, 4, 5 };
            int[] expected = a2;
            LinkedListNode l2 = BuildList(a2);
            LinkedListNode result = linkedListMerger.MergeLists(l1, l2);
            CheckList(expected, result);
        }

        private void MergeTest(ILinkedListMerger linkedListMerger)
        {
            int[] a1 = new int[] { 1, 3, 6 };
            int[] a2 = new int[] { 2, 4, 5 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            LinkedListNode l1 = BuildList(a1);
            LinkedListNode l2 = BuildList(a2);
            LinkedListNode result = linkedListMerger.MergeLists(l1, l2);
            CheckList(expected, result);
        }

        private LinkedListNode BuildList(int[] a2)
        {
            LinkedListNode head = null;
            LinkedListNode prev = null;
            for (int i = 0; i < a2.Length; i++)
            {
                LinkedListNode node = new LinkedListNode(a2[i]);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    prev.Next = node;
                }
                prev = node;
            }
            return head;
        }

        private void CheckList(int[] expected, LinkedListNode result)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result.Value);
                result = result.Next;
            }
        }
    }
}
