using System;
using System.Diagnostics;
using System.Linq;
using TestSort.Algorithms;

namespace TestSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var newArray = true;
            var data = new int[0];
            var initData = new int[0];
            while (true)
            {
                if (newArray)
                {
                    initData = ProvideData();
                }

                Console.WriteLine("Use pre-sort? (0-not use, 1-ask, 2-desc)");

                var presort = InputInt();
                data = ProvideOrderedData(initData, presort);

                Console.WriteLine("Use quick sort median pivot selection? (1-yes)");
                var quickSortThreeMid = InputInt() == 1;

                NativeSort(data);

                DoSort("Merge sort", new MergeSort(data));

                DoSort("Heap sort", new HeapSort(data));

                DoSort("Quick sort", new QuickSort(data, quickSortThreeMid));

                DoSort("Insertion sort", new InsertionSort(data));

                DoSort("Selection sort", new SelectionSort(data));

                Console.WriteLine("Press q to exit, n to continue with new data, or any other key to continue with current data");

                CheckExitCodeAndThrowOrNewSession(Console.ReadLine(), ref newArray);
            }
        }

        private static void NativeSort(int[] data)
        {
            Console.WriteLine("Native sort");

            var copy = new int[data.Length];
            data.CopyTo(copy, 0);
            var commonStopWatch = new Stopwatch();
            commonStopWatch.Start();

            copy = copy.OrderBy(x => x).ToArray();

            commonStopWatch.Stop();

            Console.WriteLine(commonStopWatch.Elapsed);
        }

        private static int[] ProvideData()
        {
            Console.WriteLine("Input array length:");
            var num = InputInt();

            var data = new int[num];

            var rnd = new Random();
            for (var i = 0; i < num; i++)
            {
                data[i] = rnd.Next(0, num);
            }

            return data;
        }

        private static int[] ProvideOrderedData(int[] initData, int presort)
        {
            return presort switch
            {
                0 => initData.ToArray(),
                1 => initData.ToArray().OrderBy(x => x).ToArray(),
                _ => initData.ToArray().OrderByDescending(x => x).ToArray()
            };
        }

        private static void DoSort(string title, SortInt sorting)
        {
            Console.WriteLine(title);

            var result = sorting.Sort();

            Console.WriteLine(result);
        }

        private static int InputInt()
        {
            GetValue:
            var value = Console.ReadLine();

            CheckExitCodeAndThrow(value);

            if (!int.TryParse(value, out var result) || result < 0)
            {
                Console.WriteLine("Please, input correct integer value >= 0");
                goto GetValue;
            }

            return result;
        }

        private static void CheckExitCodeAndThrowOrNewSession(string value, ref bool newArray)
        {
            if (value.ToLower() == "n")
            {
                newArray = true;
                return;
            }
            newArray = false;
            CheckExitCodeAndThrow(value);
        }

        private static void CheckExitCodeAndThrow(string value)
        {
            if(value.ToLower() == "q")
                throw new ExitException();
        }
    }
}
