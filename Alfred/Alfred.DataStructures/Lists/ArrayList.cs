using System.Collections;

namespace Alfred.DataStructures.Lists
{
    /// <summary>
    /// A barebone, dynamic array that can grow or shrink in size.
    /// </summary>
    /// <typeparam name="T">The type of the values contained in the ArrayList.</typeparam>
    public class ArrayList<T> : IList<T>
    {
        /// <summary>
        /// Collection of items.
        /// </summary>
        private T[] Items { get; set; }

        /// <summary>
        /// The current capacity of the collection.
        /// </summary>
        public int CurrentCapacity => Items.Length;
        /// <summary>
        /// Number of items in the collection.
        /// </summary>
        public int Length { get; private set; }

        public ArrayList()
            : this(initialCapacity: 8)
        { }

        public ArrayList(int initialCapacity)
        {
            Items = new T[initialCapacity];
            Length = 0;
        }

        /// <summary>
        /// Indexer for the collection.
        /// </summary>
        /// <paramref name="index">The index of the item to get or set.</paramref>
        /// <remarks>
        /// Throws an <see cref="IndexOutOfRangeException"/> if the index is less than 0 or greater than or equal to the length of the collection.
        /// </remarks>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return Items[index];
            }
        }

        /// <summary>
        /// Inserts a value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index at which to insert the value.
        /// </param>
        /// <param name="value">
        /// The value to insert.
        /// </param>
        /// <remarks>
        /// Time complexity: O(n)
        /// </remarks>
        public void Insert(int index, T value)
        {
            if (Length == Items.Length)
            {
                DoubleCapacity();
            }

            var correctIndex = CalculateCorrectIndex(index);
            ShiftRight(correctIndex);

            Items[correctIndex] = value;
            Length++;
        }

        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index of the value to remove.
        /// </param>
        /// <returns>
        /// The value that was removed.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the collection.
        /// </exception>
        /// <remarks>
        /// Time complexity: O(n)
        /// </remarks>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            var value = Items[index];
            ShiftLeft(index);
            Length--;

            if (Length < CurrentCapacity / 4)
            {
                ReduceCapacity();
            }

            return value;
        }

        public IEnumerator<T> GetEnumerator() => new ArrayListEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ReduceCapacity()
        {
            T[] newItems = new T[CurrentCapacity / 2];
            for (var i = 0; i < Length; i++)
            {
                newItems[i] = Items[i];
            }
            Items = newItems;
        }

        private void DoubleCapacity()
        {
            var newItems = new T[Items.Length * 2];
            for (var i = 0; i < Items.Length; i++)
            {
                newItems[i] = Items[i];
            }
            Items = newItems;
        }

        private void ShiftLeft(int index)
        {
            for (var i = index + 1; i < Length; i++)
            {
                Items[i - 1] = Items[i];
            }
        }

        private void ShiftRight(int index)
        {
            for (var i = Length; i > index; i--)
            {
                Items[i] = Items[i - 1];
            }
        }

        private int CalculateCorrectIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > Length)
            {
                return Length;
            }
            return index;
        }
    }
}
