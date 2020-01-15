namespace TestSort.Algorithms
{
    public class SelectionSort : SortInt
    {
        public SelectionSort(int[] data)
            : base(data)
        {
        }

        protected override void SortInner()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                var temp = i;
                Result.OperationsCount++;

                for (var j = i + 1; j < Data.Length; j++)
                {
                    Result.EntriesCount++;

                    if (Data[j] < Data[temp])
                    {
                        temp = j;
                        Result.OperationsCount++;
                    }
                }

                if (i != temp)
                {
                    var ex = Data[i];
                    Data[i] = Data[temp];
                    Data[temp] = ex;

                    Result.OperationsCount += 3;
                }
            }
        }
    }
}