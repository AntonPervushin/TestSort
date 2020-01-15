using NUnit.Framework;

namespace TestSort.Algorithms.Tests
{
    public class InsertionSortTest : SortTest
    {
        [Test]
        public void SortIsOk()
        {
            Assert.IsTrue(CheckSort(new InsertionSort(Data)));
        }
    }
}
