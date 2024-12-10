namespace Alfred.DataStructures.Lists
{
    public interface ISortableList<T> : IList<T>
        where T : IComparable<T>
    {
        void Sort();
    }
}
