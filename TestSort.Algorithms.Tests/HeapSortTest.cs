using NUnit.Framework;
using NUnit.Framework;

namespace TestSort.Algorithms.Tests
{
    public class HeapSortTest : SortTest
    {
        [Test]
        public void SortIsOk()
        {
            Assert.IsTrue(CheckSort(new HeapSort(Data)));
        }
    }
}
