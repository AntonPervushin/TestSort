using NUnit.Framework;

namespace TestSort.Algorithms.Tests
{
    public class MergeSortTest : SortTest
    {
        [Test]
        public void SortIsOk()
        {
            Assert.IsTrue(CheckSort(new MergeSort(Data)));
        }
    }
}
