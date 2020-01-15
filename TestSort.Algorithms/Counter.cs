using System;
using System.Diagnostics;

namespace TestSort.Algorithms
{
    public class Counter
    {
        private readonly Stopwatch _stopwatch;

        public Counter()
        {
            _stopwatch = new Stopwatch();
            Count = 0;
        }

        public int Count { get; private set; }
        public TimeSpan Elapsed => _stopwatch.Elapsed;

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
            Count++;
        }
    }
}
