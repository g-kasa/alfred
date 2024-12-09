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

        /// <summary>
        /// Creates a new instance of the <see cref="ArrayList{T}"/> class.
        /// </summary>
        public ArrayList()
            : this(initialCapacity: 8)
        { }

        /// <summary>
        /// Creates a new instance of the <see cref="ArrayList{T}"/> class.
        /// </summary>
        /// <param name="initialCapacity">
        /// The initial capacity of the collection.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the initial capacity is negative.
        /// </exception>
        public ArrayList(int initialCapacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(initialCapacity);

            Items = new T[initialCapacity];
            Length = 0;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ArrayList{T}"/> class.
        /// </summary>
        /// <param name="item">
        /// The first item in the collection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If the item is null.
        /// </exception>
        public ArrayList(T item)
            : this()
        {
            ArgumentNullException.ThrowIfNull(item);

            Items[0] = item;
            Length = 1;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ArrayList{T}"/> class.
        /// </summary>
        /// <param name="items">
        /// The items to add to the collection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If the items are null.
        /// </exception>
        public ArrayList(IEnumerable<T> items)
            : this(items.Count())
        {
            ArgumentNullException.ThrowIfNull(items);

            foreach (var item in items)
            {
                Insert(Length, item);
            }
        }

        /// <summary>
        /// Indexer for the collection.
        /// </summary>
        /// <paramref name="index">The index of the item to get or set.</paramref>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the collection.
        /// </exception>
        public T this[int index]
        {
            get
            {
                ArgumentOutOfRangeException.ThrowIfNegative(index);
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

                return Items[index];
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(index);
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

                Items[index] = value;
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
        /// <exception cref="ArgumentNullException">
        /// If the value is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index is less than 0.
        /// </exception>
        /// <remarks>
        /// Time complexity: O(n)
        /// </remarks>
        public void Insert(int index, T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            ArgumentOutOfRangeException.ThrowIfNegative(index);

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
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the collection.
        /// </exception>
        /// <remarks>
        /// Time complexity: O(n)
        /// </remarks>
        public T RemoveAt(int index)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

            var value = Items[index];
            ShiftLeft(index);
            Length--;

            if (Length < CurrentCapacity / 4)
            {
                ReduceCapacity();
            }

            return value;
        }

        /// <summary>
        /// Finds the index of the specified item.
        /// </summary>
        /// <param name="item">
        /// The item to find.
        /// </param>
        /// <returns>
        /// The index of the item, or -1 if the item is not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the item is null.
        /// </exception>
        public int IndexOf(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (var i = 0; i < Length; i++)
            {
                if (Items[i]!.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Finds all the indices of the specified item.
        /// </summary>
        /// <param name="item">
        /// The item to find.
        /// </param>
        /// <returns>
        /// The indices of the item, if found.
        /// </returns>
        public IEnumerable<int> IndicesOf(T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            for (var i = 0; i < Length; i++)
            {
                if (Items[i]!.Equals(item))
                {
                    yield return i;
                }
            }

            yield break;
        }

        public IEnumerator<T> GetEnumerator() => new ArrayListEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ReduceCapacity()
        {
            if (CurrentCapacity == 1)
            {
                return;
            }

            T[] newItems = new T[CurrentCapacity / 2];
            for (var i = 0; i < Length; i++)
            {
                newItems[i] = Items[i];
            }
            Items = newItems;
        }

        private void DoubleCapacity()
        {
            var newItems = new T[Items.Length == 0 ? 2 : Items.Length * 2];
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
