using System;
using System.Collections.Generic;
using System.Linq;

namespace TestSort.Algorithms
{
    public class QuickSort : SortInt
    {
        private readonly bool _threeMidPivotMode;
        private readonly Stack<Tuple<int, int>> _stack;

        public QuickSort(int[] data, bool threeMidPivotMode)
            : base(data)
        {
            _threeMidPivotMode = threeMidPivotMode;
            _stack = new Stack<Tuple<int, int>>();
        }

        protected override void SortInner()
        {
            _stack.Push(new Tuple<int, int>(0, Data.Length - 1));

            while (true)
            {
                if (!_stack.Any()) return;

                var current = _stack.Pop();
                var from = current.Item1;
                var to = current.Item2;

                var res = PartitionSort(from, to);
                if (res != null)
                {
                    _stack.Push(new Tuple<int, int>(res.Item1, res.Item2 - 1));
                    _stack.Push(new Tuple<int, int>(res.Item2 + 1, res.Item3));
                }
            }
        }

        private Tuple<int, int, int> PartitionSort(int from, int to)
        {
            if (from >= to) return null;
            if (_threeMidPivotMode)
            {
                var pivotIndex = GetMedianIndex(Data, from, to);

                if (pivotIndex != to)
                {
                    var temp = Data[to];
                    Data[to] = Data[pivotIndex];
                    Data[pivotIndex] = temp;
                    Result.OperationsCount+=3;
                }
            }

            var pivot = Data[to];
            var boundaryIndex = from;

            for (var i = from; i < to; i++)
            {
                Result.EntriesCount++;
                if (Data[i] <= pivot)
                {
                    if (boundaryIndex != i)
                    {
                        var temp = Data[i];
                        Data[i] = Data[boundaryIndex];
                        Data[boundaryIndex] = temp;
                        Result.OperationsCount += 3;
                    }

                    boundaryIndex++;
                }
            }

            var temp2 = Data[boundaryIndex];
            Data[boundaryIndex] = Data[to];
            Data[to] = temp2;
            Result.OperationsCount += 3;

            return  new Tuple<int, int, int>(from, boundaryIndex, to);
        }

        private int GetMedianIndex(int[] Data, int from, int to)
        {
            if (Data.Length <= 2) return from;

            var mid = from + (to - from) / 2;

            if (Data[from] >= Data[mid] && Data[from] <= Data[to] ||
                Data[from] >= Data[to] && Data[from] <= Data[mid]) 
                return from;

            if (Data[mid] >= Data[from] && Data[mid] <= Data[to] ||
                Data[mid] >= Data[to] && Data[mid] <= Data[from])
                return mid;

            return to;
        }
    }
}
