using NUnit.Framework;
using System;
using System.Linq;
using TestSort.Algorithms.Trees.Int;

namespace TestSort.Algorithms.Tests
{
    public class CommonTreeTests
    {
        [Test]
        public void EmptyBSTree_Is_BSTree()
        {
            var tree = ProvideTree();

            Assert.IsTrue(tree.CheckIsSearchTree());
        }
        
        [Test]
        public void FilledBSTree_Is_BSTree()
        {
            var tree = ProvideTree(new int[] { 50, 10, 5, 1, 1, 10, 100 });

            Assert.IsTrue(tree.CheckIsSearchTree());
        }

        [Test]
        public void FillRamdomly_IsSorted()
        {
            var min = -1000;
            var max = 1000;
            var randNum = new Random();
            var testArray = Enumerable.Range(min, max).OrderBy(g => Guid.NewGuid()).ToArray();
            var tree = ProvideTree(testArray);

            var treeSorted = tree.InorderWalk().ToArray();
            var inputSorted = testArray.OrderBy(x => x).ToArray();

            CollectionAssert.AreEqual(inputSorted, treeSorted);
        }

        [Test]
        public void SearchNotExists_GetNull()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, 1, 10, 100 });

            var notExistValue = tree.Search(200);

            Assert.IsNull(notExistValue);
        }

        [Test]
        public void SearchExists_GetOne()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, 1, 10, 100 });

            var existValue = tree.Search(1);

            Assert.IsTrue(existValue.Key == 1);
        }

        [Test]
        public void GetMin_IsOk()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, -5, 1, 10, 100 });

            var min = tree.Min().Key;

            Assert.AreEqual(-5, min);
        }

        [Test]
        public void GetMax_IsOk()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, -5, 1, 10, 100 });

            var max = tree.Max().Key;

            Assert.AreEqual(100, max);
        }

        [Test]
        public void GetSuccessor_IsOk()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, -5, 1, 10, 100 });

            var successor = tree.Successor(10).Key;

            Assert.AreEqual(50, successor);
        }

        [Test]
        public void GetPredecessor_IsOk()
        {
            var tree = ProvideTree(new int[] { 2, 50, 1, -5, 1, 10, 100 });

            var predecessor = tree.Predecessor(10).Key;

            Assert.AreEqual(2, predecessor);
        }

        [Test]
        public void FilledBSTree_DeleteItem_Is_BSTree()
        {
            var inputData = new int[] { 2, 50, 1, 10, 12, 11, 9, 7, 100 };
            var tree = ProvideTree(inputData);

            tree.Delete(10);
            var countAfterDelete = tree.InorderWalk().Count();

            Assert.IsTrue(tree.CheckIsSearchTree());
            Assert.AreEqual(inputData.Length - 1, countAfterDelete);
        }


        [Test]
        public void LeftRotation_IsOk()
        {
            var inputData = new int[] { 2, 50, 1, 10, 11, 12, 13, 9, 7, 100 };
            var tree = ProvideTree(inputData);

            var pivotKey = 11;
            var pivot = tree.Search(pivotKey);
            tree.LeftRotation(pivotKey);

            var treeSorted = tree.InorderWalk().ToArray();
            Assert.IsTrue(tree.CheckIsSearchTree());
            CollectionAssert.AreEqual(inputData.OrderBy(x => x).ToArray(), treeSorted);
            Assert.AreEqual(10, pivot.Left.Key);
            Assert.AreEqual(12, pivot.Right.Key);
        }

        [Test]
        public void RightRotation_IsOk()
        {
            var inputData = new int[] { 2, 50, 1, 12, 11, 10, 13, 9, 7, 100 };
            var tree = ProvideTree(inputData);

            var pivotKey = 11;
            var pivot = tree.Search(pivotKey);
            tree.RightRotation(pivotKey);

            var treeSorted = tree.InorderWalk().ToArray();
            Assert.IsTrue(tree.CheckIsSearchTree());
            CollectionAssert.AreEqual(inputData.OrderBy(x => x).ToArray(), treeSorted);
            Assert.AreEqual(10, pivot.Left.Key);
            Assert.AreEqual(12, pivot.Right.Key);
        }

        [Test]
        public void LeftRightRotation_IsOk()
        {
            var inputData = new int[] { 2, 50, 1, 12, 10, 11, 13, 9, 7, 100 };
            var tree = ProvideTree(inputData);

            var pivotKey = 11;
            tree.LeftRightRotation(pivotKey);
            var pivot = tree.Search(pivotKey);

            var treeSorted = tree.InorderWalk().ToArray();
            Assert.IsTrue(tree.CheckIsSearchTree());
            CollectionAssert.AreEqual(inputData.OrderBy(x => x).ToArray(), treeSorted);
            Assert.AreEqual(10, pivot.Left.Key);
            Assert.AreEqual(12, pivot.Right.Key);
        }

        [Test]
        public void RightLeftRotation_IsOk()
        {
            var inputData = new int[] { 2, 50, 1, 10, 12, 11, 13, 9, 7, 100 };
            var tree = ProvideTree(inputData);

            var pivotKey = 11;
            tree.RightLeftRotation(pivotKey);
            var pivot = tree.Search(pivotKey);

            var treeSorted = tree.InorderWalk().ToArray();
            Assert.IsTrue(tree.CheckIsSearchTree());
            CollectionAssert.AreEqual(inputData.OrderBy(x => x).ToArray(), treeSorted);
            Assert.AreEqual(10, pivot.Left.Key);
            Assert.AreEqual(12, pivot.Right.Key);
        }

        private IntBinarySearchTree ProvideTree(int[] data = null)
        {
            var intTree = new IntBinarySearchTree();
            if (data == null) return intTree;

            foreach(var item in data)
            {
                intTree.Insert(item);
            }

            return intTree;
        }
    }
}
