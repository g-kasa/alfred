namespace Alfred.DataStructures.Lists
{
    /// <summary>
    /// A list of items.
    /// </summary>
    public interface IList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Get the value at the specified index.
        /// </summary>
        T this[int index] { get; set; }

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        int Length { get; }
        /// <summary>
        /// Inserts a value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index at which to insert the value.
        /// </param>
        /// <param name="value">
        /// The value to insert.
        /// </param>
        void Insert(int index, T value);
        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index of the value to remove.
        /// </param>
        /// <returns>
        /// The value that was removed.
        /// </returns>
        T RemoveAt(int index);
        /// <summary>
        /// Finds the index of the specified item.
        /// </summary>
        /// <param name="item">
        /// The item to find.
        /// </param>
        /// <returns>
        /// The index of the item, or -1 if the item is not found.
        /// </returns>
        int IndexOf(T item);
        /// <summary>
        /// Finds all the indices of the specified item.
        /// </summary>
        /// <param name="item">
        /// The item to find.
        /// </param>
        /// <returns>
        /// The indices of the item, if found.
        /// </returns>
        IEnumerable<int> IndicesOf(T item);
    }
}
