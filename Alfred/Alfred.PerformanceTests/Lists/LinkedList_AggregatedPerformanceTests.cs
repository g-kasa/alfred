using Alfred.PerformanceTests.Models;
using AlfredDataStructures = Alfred.DataStructures.Lists;

namespace Alfred.PerformanceTests.Lists
{
    public static class LinkedList_AggregatedPerformanceTests
    {
        private static int[] Sizes { get; } = [10, 100, 1000, 10000, 100000];

        public static PerformanceMetrics[] RunAllTests()
            => RunAllTests(Sizes);
        public static PerformanceMetrics[] RunAllTests(int[] sizes)
        {
            var metricsList = new AlfredDataStructures.LinkedList<PerformanceMetrics>();
            foreach (var size in sizes)
            {
                foreach (var metric in RunAllTests(size))
                {
                    metricsList.Insert(metricsList.Length, metric);
                }
            }
            return [.. metricsList];
        }

        public static IEnumerable<PerformanceMetrics> RunAllTests(int size)
        {
            yield return LinkedList_PerformanceTest.TestAppend(size);
            yield return LinkedList_PerformanceTest.TestInsertInTheBeginning(size);
            yield return LinkedList_PerformanceTest.TestInsertInTheMiddle(size);
            yield return LinkedList_PerformanceTest.TestRemoveLast(size);
            yield return LinkedList_PerformanceTest.TestRemoveFirst(size);
            yield return LinkedList_PerformanceTest.TestRemoveInTheMiddle(size);
            yield break;
        }
    }
}
