using NUnit.Framework;
using System;
using System.Linq;

namespace TestSort.Algorithms.Tests
{
    public abstract class SortTest
    {
        protected int[] Data;
        protected int[] OrderedData;

        [OneTimeSetUp]
        public void Setup()
        {
            const int num = 1000;
            Data = new int[num];

            var rnd = new Random();
            for (var i = 0; i < num; i++)
            {
                Data[i] = rnd.Next(0, num);
            }

            OrderedData = Data.OrderBy(x => x).ToArray();
        }

        protected bool CheckSort(SortInt sortAlgorithm)
        {
            sortAlgorithm.Sort();

            for (var i = 0; i < OrderedData.Length; i++)
            {
                if (OrderedData[i] != sortAlgorithm.Data[i])
                    return false;
            }

            return true;
        }
    }
}