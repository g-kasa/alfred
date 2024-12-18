using Alfred.PerformanceTests.Lists;
using Alfred.PerformanceTests.Models;
using System.Collections.Generic;
using System.Data;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var performanceMetrics = new List<PerformanceMetrics>();
        int numberOfTests = 100;
        var arrayListMetrics = new List<PerformanceMetrics>();
        var arrayListOptimizeExecutionTimeMetrics = new List<PerformanceMetrics>();
        var linkedListMetrics = new List<PerformanceMetrics>();

        // Test Append
        var b = 2;
        for (int exp = 1; exp <= 14; exp++)
        {
            var size = (int)Math.Pow(b, exp);
            for (int i = 0; i < numberOfTests; i++)
            {
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestAppend(size));
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestInsertInTheBeginning(size));
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestInsertInTheMiddle(size));
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestRemoveLast(size));
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestRemoveFirst(size));
                arrayListMetrics.Add(ArrayList_PerformanceTests.TestRemoveInTheMiddle(size));

                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestAppend(size));
                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestInsertInTheBeginning(size));
                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestInsertInTheMiddle(size));
                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveLast(size));
                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveFirst(size));
                arrayListOptimizeExecutionTimeMetrics.Add(ArrayListOptimizedExecutionTime_PerformanceTests.TestRemoveInTheMiddle(size));

                linkedListMetrics.Add(LinkedList_PerformanceTest.TestAppend(size));
                linkedListMetrics.Add(LinkedList_PerformanceTest.TestInsertInTheBeginning(size));
                linkedListMetrics.Add(LinkedList_PerformanceTest.TestInsertInTheMiddle(size));
                linkedListMetrics.Add(LinkedList_PerformanceTest.TestRemoveLast(size));
                linkedListMetrics.Add(LinkedList_PerformanceTest.TestRemoveFirst(size));
                linkedListMetrics.Add(LinkedList_PerformanceTest.TestRemoveInTheMiddle(size));
            }
        }

        performanceMetrics.AddRange(arrayListMetrics);
        performanceMetrics.AddRange(arrayListOptimizeExecutionTimeMetrics);
        performanceMetrics.AddRange(linkedListMetrics);

        // Get overall performance metrics 

        // Pivot per operation
        var dataTable = new DataTable();
        dataTable.Columns.Add("Operation", typeof(string));
        dataTable.Columns.Add("Input Length", typeof(int));
        dataTable.Columns.Add("Class", typeof(string));
        dataTable.Columns.Add("Elapsed Ticks", typeof(long));
        dataTable.Columns.Add("Elapsed Milliseconds", typeof(long));
        dataTable.Columns.Add("Input Size - Before Test (bytes)", typeof(long));
        dataTable.Columns.Add("Input Size - After Test (bytes)", typeof(long));
        dataTable.Columns.Add("Average Ticks Per Item", typeof(decimal));
        dataTable.Columns.Add("Average Milliseconds Per Item", typeof(decimal));
        var metricsPerOperation = performanceMetrics.GroupBy(metrics => metrics.Operation);
        foreach (var grouping in metricsPerOperation)
        {
            var operation = grouping.Key;
            var perSizeSubGroup = grouping.GroupBy(metrics => metrics.InputLength);

            foreach (var subGroup in perSizeSubGroup)
            {
                var inputLength = subGroup.Key;

                var subGroupItems = subGroup.OrderBy(subGroup => subGroup.Class);

                foreach (var item in subGroupItems)
                {
                    dataTable.Rows.Add(
                        operation,
                        inputLength,
                        item.Class,
                        item.ElapsedTicks,
                        item.ElapsedMilliseconds,
                        item.InputSizeInBytes_BeforeTest,
                        item.InputSizeInBytes_AfterTest,
                        item.AverageTicksPerItem,
                        item.AverageMillisecondsPerItem);
                }
            }
        }

        // Convert datatable to csv
        var sb = new StringBuilder();
        IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().
                                          Select(column => column.ColumnName);
        sb.AppendLine(string.Join(",", columnNames));
        foreach (DataRow row in dataTable.Rows)
        {
            IEnumerable<string> fields = row.ItemArray
                .Select(field => string.Concat("\"", field?.ToString()?.Replace("\"", "\"\""), "\""));
            sb.AppendLine(string.Join(",", fields));
        }

        File.WriteAllText($"C:\\Users\\GentianKasa\\Downloads\\test_{DateTime.UtcNow.ToString("yyyyMMdd-HHmmss")}.csv", sb.ToString());
    }
}