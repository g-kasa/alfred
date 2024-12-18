using Alfred.PerformanceTests.Models;
using AlfredDataStructures = Alfred.DataStructures.Lists;
using System.Diagnostics;
using System.Text.Json;

namespace Alfred.PerformanceTests.Lists
{
    public static class LinkedList_PerformanceTest
    {
        public static PerformanceMetrics TestAppend(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(list.Length, i),
                "Append");
            return result;
        }
        public static PerformanceMetrics TestInsertInTheBeginning(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(0, i),
                "InsertInTheBeginning");
            return result;
        }
        public static PerformanceMetrics TestInsertInTheMiddle(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(list.Length / 2, i),
                "InsertInTheMiddle");
            return result;
        }
        public static PerformanceMetrics TestRemoveLast(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(0, i),
                (AlfredDataStructures.LinkedList<int> list, int i) => list.RemoveAt(list.Length - 1),
                "RemoveLast");
            return result;
        }
        public static PerformanceMetrics TestRemoveFirst(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(0, i),
                (AlfredDataStructures.LinkedList<int> list, int i) => list.RemoveAt(0),
                "RemoveFirst");
            return result;
        }
        public static PerformanceMetrics TestRemoveInTheMiddle(int size)
        {
            var result = TestPerformance(
                size,
                (AlfredDataStructures.LinkedList<int> list, int i) => list.Insert(0, i),
                (AlfredDataStructures.LinkedList<int> list, int i) => list.RemoveAt(list.Length / 2),
                "RemoveInTheMiddle");
            return result;
        }
        private static PerformanceMetrics TestPerformance(
            int size,
            Action<AlfredDataStructures.LinkedList<int>, int> warmup,
            Action<AlfredDataStructures.LinkedList<int>, int> test,
            string operation)
        {
            var list = new AlfredDataStructures.LinkedList<int>();
            // Warmup
            for (var i = 0; i < size; i++)
            {
                warmup(list, i);
            }
            var sizeOfList_BeforeTest = GetSize(list);
            var stopwatch = new Stopwatch();
            // Test
            stopwatch.Start();
            for (var i = 0; i < size; i++)
            {
                test(list, i);
            }
            stopwatch.Stop();

            var sizeOfList_AfterTest = GetSize(list);
            return new PerformanceMetrics
            {
                Class = nameof(AlfredDataStructures.LinkedList<int>),
                Operation = operation,
                InputLength = size,
                InputSizeInBytes_BeforeTest = sizeOfList_BeforeTest,
                InputSizeInBytes_AfterTest = sizeOfList_AfterTest,
                ElapsedTicks = stopwatch.ElapsedTicks
            };
        }

        private static long GetSize(AlfredDataStructures.LinkedList<int> list)
        {
            using (var stream = new MemoryStream())
            {
                JsonSerializer.Serialize(stream, list);
                return stream.Length;
            }
        }
    }
}
