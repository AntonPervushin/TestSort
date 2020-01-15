namespace TestSort.Algorithms
{
    public class InsertionSort : SortInt
    {
        public InsertionSort(int[] Data) 
            : base(Data)
        {
        }

        protected override void SortInner()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                for (var j = i; j > 0; j--)
                {
                    Result.EntriesCount++;

                    if (Data[j] < Data[j - 1])
                    {
                        var temp = Data[j];
                        Data[j] = Data[j - 1];
                        Data[j - 1] = temp;

                        Result.OperationsCount += 3;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
