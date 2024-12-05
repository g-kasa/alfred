namespace Alfred.DataStructures.Queues
{
    /// <summary>
    /// Enum to specify the priority type.
    /// </summary>
    /// <remarks>
    /// - MinFirst -> The item with the minimum priority is dequeued first.
    /// - MaxFirst -> The item with the maximum priority is dequeued first.
    /// </remarks>
    public enum PriorityType
    {
        MinFirst,
        MaxFirst
    }
}
