using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace PerformancePlayground.Console
{
    public class ReadonlyVersusNonReadonlyList
    {
        private List<string> _nonReadOnlyList = new List<string>(42);
        private readonly List<string> _readOnlyList = new List<string>(42);
        private readonly string[] _data = Enumerable.Range(1, 100_000).Select(x => x.ToString()).ToArray();

        [Benchmark]
        public int AggregateForNonReadOnlyField()
        {
            int result = 0;
            foreach (string n in _data)
                _nonReadOnlyList.Add(n);
            return result;
        }

        [Benchmark]
        public int AggregateForReadOnlyField()
        {
            int result = 0;
            foreach (string n in _data)
                _readOnlyList.Add(n);
            return result;
        }
    }
}