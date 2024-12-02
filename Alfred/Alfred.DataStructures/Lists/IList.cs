﻿namespace Alfred.DataStructures.Lists
{
    /// <summary>
    /// A list of items.
    /// </summary>
    public interface IList<T>
    {
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
    }
}