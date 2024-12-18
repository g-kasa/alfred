using Alfred.DataStructures.Lists;
using Alfred.PerformanceTests.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Alfred.PerformanceTests.Lists
{
    public static class ArrayList_PerformanceTests
    {
        public static PerformanceMetrics TestAppend(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (ArrayList<int> list, int i) => list.Insert(list.Length, i),
                "Append");

            return result;
        }

        public static PerformanceMetrics TestInsertInTheBeginning(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (ArrayList<int> list, int i) => list.Insert(0, i),
                "InsertInTheBeginning");

            return result;
        }

        public static PerformanceMetrics TestInsertInTheMiddle(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) =>
                {
                    list.Insert(0, i);
                    list.RemoveAt(0);
                },
                (ArrayList<int> list, int i) => list.Insert(list.Length / 2, i),
                "InsertInTheMiddle");
            return result;
        }

        public static PerformanceMetrics TestRemoveLast(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) => list.Insert(0, i),
                (ArrayList<int> list, int i) => list.RemoveAt(list.Length - 1),
                "RemoveLast");

            return result;
        }

        public static PerformanceMetrics TestRemoveInTheMiddle(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) => list.Insert(0, i),
                (ArrayList<int> list, int i) => list.RemoveAt(list.Length / 2),
                "RemoveInTheMiddle");
            return result;
        }

        public static PerformanceMetrics TestRemoveFirst(int size)
        {
            var result = TestPerformance(
                size,
                (ArrayList<int> list, int i) => list.Insert(0, i),
                (ArrayList<int> list, int i) => list.RemoveAt(0),
                "RemoveFirst");

            return result;
        }

        private static PerformanceMetrics TestPerformance(
            int size, 
            Action<ArrayList<int>, int> warmup, 
            Action<ArrayList<int>, int> test, 
            string actionName)
        {
            var list = new ArrayList<int>();
            // Warmup
            for (int i = 0; i < size; i++)
            {
                warmup(list, i);
            }
            var sizeOfList_BeforeTest = GetSize(list);
            var stopwatch = new Stopwatch();
            // Test
            stopwatch.Start();
            for (int i = 0; i < size; i++)
            {
                test(list, i);
            }
            stopwatch.Stop();
            var sizeOfList_AfterTest = GetSize(list);
            var result = new PerformanceMetrics
            {
                Class = nameof(ArrayList<int>),
                Operation = actionName,
                InputLength = size,
                ElapsedTicks = stopwatch.ElapsedTicks,
                InputSizeInBytes_BeforeTest = sizeOfList_BeforeTest,
                InputSizeInBytes_AfterTest = sizeOfList_AfterTest
            };
            return result;
        }

        private static long GetSize(ArrayList<int> list)
        {
            using (var stream = new MemoryStream())
            {
                JsonSerializer.Serialize(stream, list);
                return stream.Length;
            }
        }
    }
}
