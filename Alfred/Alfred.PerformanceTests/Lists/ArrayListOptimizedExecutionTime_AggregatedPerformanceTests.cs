using Alfred.DataStructures.Lists;
using Alfred.PerformanceTests.Models;

namespace Alfred.PerformanceTests.Lists
{
    public static class ArrayListOptimizedExecutionTime_AggregatedPerformanceTests
    {
        private static int[] Sizes { get; } = [10, 100, 1000, 10000, 100000];

        public static PerformanceMetrics[] RunAllTests()
            => RunAllTests(Sizes);
        public static PerformanceMetrics[] RunAllTests(int[] sizes)
        {
            var metricsList = new ArrayListOptimizedExecutionTime<PerformanceMetrics>();
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
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestAppend(size);
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestInsertInTheBeginning(size);
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestInsertInTheMiddle(size);
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveLast(size);
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveFirst(size);
            yield return ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveInTheMiddle(size);
            yield break;
        }
    }
}
