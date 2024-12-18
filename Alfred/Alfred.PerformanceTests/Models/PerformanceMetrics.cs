namespace Alfred.PerformanceTests.Models
{
    public class PerformanceMetrics
    {
        private const int TicksPerMillisecond = 10000;

        public string Class { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public int InputLength { get; set; }
        public long InputSizeInBytes_BeforeTest { get; set; }
        public long InputSizeInBytes_AfterTest { get; set; }
        public long ElapsedTicks { get; set; }
        public long ElapsedMilliseconds => ElapsedTicks / TicksPerMillisecond;
        public decimal AverageTicksPerItem => ElapsedTicks / (decimal)InputLength;
        public decimal AverageMillisecondsPerItem => ElapsedMilliseconds / (decimal)InputLength;

        public PerformanceMetrics() { }

        public override string ToString()
        {
            return $"Class: {Class}, Operation: {Operation}, Input Length: {InputLength}, Input size - before test (bytes): {InputSizeInBytes_BeforeTest}, Input size - after test (bytes): {InputSizeInBytes_AfterTest}, ElapsedTicks: {ElapsedTicks} ({AverageTicksPerItem} per item), ElapsedMilliseconds: {ElapsedMilliseconds} ({AverageMillisecondsPerItem} per item)";
        }
    }
}
