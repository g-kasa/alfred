namespace Alfred.DataStructures.Lists
{
    public interface ISortedList<T> : IList<T>
        where T : IComparable<T>
    {
        ISortedList<T> Merge(ISortedList<T> otherList);
    }
}
