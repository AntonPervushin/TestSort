namespace TestSort.Algorithms
{
    public class MergeSort : SortInt
    {
        public MergeSort(int[] data)
            : base(data)
        {
        }

        protected override void SortInner()
        {
            MergeAndSort(Data);
        }

        private void MergeAndSort(int[] data)
        {
            if (data.Length == 1) return;

            var middle = data.Length / 2;

            var left = new int[middle];
            var right = new int[data.Length - middle];

            Result.ExtraAllocationsElements += (uint)data.Length;

            for (var i = 0; i < middle; i++)
            {
                left[i] = data[i];
            }

            for (var i = middle; i < data.Length; i++)
            {
                right[i - middle] = data[i];
            }

            Result.OperationsCount += (uint)data.Length;

            MergeAndSort(left);
            MergeAndSort(right);

            var leftPosition = 0;
            var rightPosition = 0;
            var position = 0;

            var getLeft = left.Length > 0;
            var getRight = right.Length > 0;

            while (position < data.Length)
            {
                if (getLeft && left.Length <= leftPosition)
                {
                    getLeft = false;
                }
                if (getRight && right.Length <= rightPosition)
                {
                    getRight = false;
                }

                if (getLeft && getRight)
                {
                    if (left[leftPosition] < right[rightPosition])
                    {
                        data[position] = left[leftPosition];
                        leftPosition++;
                    }
                    else
                    {
                        data[position] = right[rightPosition];
                        rightPosition++;
                    }
                }
                else if(getLeft)
                {
                    data[position] = left[leftPosition];
                    leftPosition++;
                }
                else if(getRight)
                {
                    data[position] = right[rightPosition];
                    rightPosition++;
                }

                Result.OperationsCount++;
                Result.EntriesCount++;

                position++;
            }
        }
    }
}
