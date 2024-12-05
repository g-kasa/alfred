namespace Alfred.DataStructures.Queues
{
    public interface IPriorityQueue<TPriority, TValue> : IQueue<Tuple<TPriority, TValue>> where TPriority : IComparable<TPriority>
    { }
}
