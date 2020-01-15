using System.Diagnostics;

namespace TestSort.Algorithms
{
    public abstract class SortInt
    {
        public readonly int[] Data;
        protected readonly SortAlgorithmResult Result;

        protected SortInt(int[] data)
        {
            Data = new int[data.Length];
            data.CopyTo(Data, 0);
            Result = new SortAlgorithmResult(data.Length);
        }

        public SortAlgorithmResult Sort()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            SortInner();

            stopWatch.Stop();

            Result.Duration = stopWatch.Elapsed;

            return Result;
        }

        protected abstract void SortInner();
    }
}
