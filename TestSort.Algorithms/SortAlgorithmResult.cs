using System;

namespace TestSort.Algorithms
{
    public class SortAlgorithmResult
    {
        private readonly int _dataLength;

        public SortAlgorithmResult(int dataLength)
        {
            _dataLength = dataLength;
        }

        public TimeSpan Duration { get; set; }
        public uint EntriesCount { get; set; }
        public uint OperationsCount { get; set; }
        public uint ExtraAllocationsElements { get; set; }

        public override string ToString()
        {
            var extra = ExtraAllocationsElements > 0
                ? $"ExtraAllocationsElements: {ExtraAllocationsElements}"
                : string.Empty;

            return
                $"Duration: {Duration}, Complexity: {GetApproxAlgorithmComplexity()}, EntriesCount: {EntriesCount}, OperationsCount: {OperationsCount} {extra}";
        }

        private string GetApproxAlgorithmComplexity()
        {
            var n = _dataLength;
            var nLogN = _dataLength * Math.Log(_dataLength, 2);
            var nSquare = Math.Pow(_dataLength, 2);

            if (NearToLeft(n, nLogN, EntriesCount))
            {
                return "O(n)";
            }
            else if (NearToLeft(nLogN, nSquare, EntriesCount))
            {
                return "O(nlog(n))";
            }

            return "O(n^2)";
        }

        private bool NearToLeft(double left, double right, double value)
        {
            var leftExp = (int) Math.Log10(left);
            var rightExp = (int)Math.Log10(right);
            var valExp = (int)Math.Log10(value);

            if (valExp <= leftExp) return true;
            if (valExp >= rightExp) return false;

            return valExp - leftExp < rightExp - valExp;
        }
    }
}
