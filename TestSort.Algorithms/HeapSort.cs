namespace TestSort.Algorithms
{
    public class HeapSort : SortInt
    {
        public HeapSort(int[] data)
            : base(data)
        {
        }

        protected override void SortInner()
        {
            MakeHeap();

            var i = Data.Length;
            while (i > 0)
            {
                var currentMax = Data[0];
                Data[0] = Data[i - 1];
                Data[i - 1] = currentMax;

                Result.OperationsCount += 3;

                i--;
                Heapify(Data, 0, i);
            }
        }

        private void MakeHeap()
        {
            for (var i = Data.Length / 2; i >= 0; i--)
            {
                Heapify(Data, i, Data.Length);
            }
        }

        private void Heapify(int[] data, int parent, int count)
        {
            Result.EntriesCount++;

            var left = 2 * parent + 1;
            var right = 2 * parent + 2;

            var biggest = parent;

            if (left < count && data[left] > data[biggest])
            {
                biggest = left;
                Result.OperationsCount++;
            }

            if (right < count && data[right] > data[biggest])
            {
                biggest = right;
                Result.OperationsCount++;
            }

            if (parent != biggest)
            {
                var temp = data[parent];
                data[parent] = data[biggest];
                data[biggest] = temp;

                Result.OperationsCount+=3;

                Heapify(data, biggest, count);
            }
        }
    }
}
