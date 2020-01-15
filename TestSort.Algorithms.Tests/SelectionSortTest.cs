using NUnit.Framework;

namespace TestSort.Algorithms.Tests
{
    public class SelectionSortTest : SortTest
    {
        [Test]
        public void SortIsOk()
        {
            Assert.IsTrue(CheckSort(new SelectionSort(Data)));
        }
    }
}
