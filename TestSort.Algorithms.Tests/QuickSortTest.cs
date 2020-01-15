using NUnit.Framework;

namespace TestSort.Algorithms.Tests
{
    public class QuickSortTest : SortTest
    {
        [Test]
        public void SortIsOk()
        {
            Assert.IsTrue(CheckSort(new QuickSort(Data, false)));
        }
    }
}
