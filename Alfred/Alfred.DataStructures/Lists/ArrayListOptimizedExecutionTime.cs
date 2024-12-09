using System.Collections;

namespace Alfred.DataStructures.Lists
{
    public class ArrayListOptimizedExecutionTime<T> : IList<T>
    {
        /// <summary>
        /// The index of the first item of the list.
        /// </summary>
        private int StartIndex { get; set; }
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
        /// Creates a new instance of the <see cref="ArrayListOptimizedExecutionTime{T}"/> class.
        /// </summary>
        public ArrayListOptimizedExecutionTime()
            : this(initialCapacity: 8)
        { }
        /// <summary>
        /// Creates a new instance of the <see cref="ArrayListOptimizedExecutionTime{T}"/> class.
        /// </summary>
        /// <param name="initialCapacity">
        /// The initial capacity of the collection.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the initial capacity is negative.
        /// </exception>
        public ArrayListOptimizedExecutionTime(int initialCapacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(initialCapacity);

            Items = new T[initialCapacity];
            StartIndex = 0;
        }
        /// <summary>
        /// Creates a new instance of the <see cref="ArrayListOptimizedExecutionTime{T}"/> class.
        /// </summary>
        /// <param name="item">
        /// The first item in the collection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If the item is null.
        /// </exception>
        public ArrayListOptimizedExecutionTime(T item)
            : this()
        {
            ArgumentNullException.ThrowIfNull(item);
            Insert(Length, item);
        }
        /// <summary>
        /// Creates a new instance of the <see cref="ArrayListOptimizedExecutionTime{T}"/> class.
        /// </summary>
        /// <param name="items">
        /// The items to add to the collection.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If the items are null.
        /// </exception>
        public ArrayListOptimizedExecutionTime(IEnumerable<T> items)
            : this(items.Count())
        {
            ArgumentNullException.ThrowIfNull(items);

            foreach (var item in items)
            {
                Insert(Length, item);
            }
        }

        /// <summary>
        /// Get or sets the value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index of the value to get or set.
        /// </param>
        /// <returns>
        /// The value at the specified index.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the collection.
        /// </exception>
        public T this[int index]
        {
            get
            {
                ArgumentOutOfRangeException.ThrowIfNegative(index);
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

                return Items[CalculateCorrectIndex(index)];
            }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(index);
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

                Items[CalculateCorrectIndex(index)] = value;
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the index is less than 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If the value is null.
        /// </exception>
        public void Insert(int index, T value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentNullException.ThrowIfNull(value);

            if (Length == Items.Length)
            {
                DoubleCapacity();
            }
            var correctIndex = CalculateCorrectIndex(index);
            var lastIndex = (StartIndex + Length) % Items.Length;
            var indexBeforeStart = CalculatePreviousIndexOf(StartIndex);
            if (correctIndex == lastIndex)
            {
                Items[correctIndex] = value;
            }
            else if (correctIndex == StartIndex)
            {
                StartIndex = indexBeforeStart;
                Items[StartIndex] = value; 
            }
            else
            {
                var itemsToMoveOnTheRight = (lastIndex > correctIndex)
                                          ? lastIndex - correctIndex
                                          : Items.Length + lastIndex - correctIndex;
                var itemsToMoveOnTheLeft = (correctIndex > StartIndex)
                                         ? correctIndex - StartIndex
                                         : Items.Length + correctIndex - StartIndex;
                if (itemsToMoveOnTheLeft < itemsToMoveOnTheRight)
                {
                    for (int i = (StartIndex + Length) % Items.Length; i != correctIndex; i = CalculatePreviousIndexOf(i))
                    {
                        Items[i] = Items[CalculatePreviousIndexOf(i)];
                    }
                }
                else
                {
                    for (int i = indexBeforeStart; i != correctIndex; i = CalculateNextIndexOf(i))
                    {
                        Items[i] = Items[CalculateNextIndexOf(i)];
                    }
                    StartIndex = indexBeforeStart;
                }

                Items[correctIndex] = value;
            }

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
        public T RemoveAt(int index)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);

            var correctIndex = CalculateCorrectIndex(index);
            var value = Items[correctIndex];
            var lastIndex = (StartIndex + Length) % Items.Length;

            if (correctIndex == StartIndex)
            {
                StartIndex = CalculateNextIndexOf(StartIndex);
            }
            else if (correctIndex != CalculatePreviousIndexOf(lastIndex))
            {
                var itemsToMoveOnTheRight = (lastIndex > correctIndex)
                                          ? lastIndex - correctIndex
                                          : Items.Length + lastIndex - correctIndex;
                var itemsToMoveOnTheLeft = (correctIndex > StartIndex)
                                         ? correctIndex - StartIndex
                                         : Items.Length + correctIndex - StartIndex;
                if (itemsToMoveOnTheLeft < itemsToMoveOnTheRight)
                {
                    for (int i = correctIndex; i != CalculatePreviousIndexOf(lastIndex); i = CalculateNextIndexOf(i))
                    {
                        Items[i] = Items[CalculateNextIndexOf(i)];
                    }
                }
                else
                {
                    for (int i = correctIndex; i != StartIndex; i = CalculatePreviousIndexOf(i))
                    {
                        Items[i] = Items[CalculatePreviousIndexOf(i)];
                    }

                    StartIndex = CalculateNextIndexOf(StartIndex);
                }
            }

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
                var currentItem = Items[CalculateCorrectIndex(i)];
                if (currentItem!.Equals(item))
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
                var currentItem = Items[CalculateCorrectIndex(i)];
                if (currentItem!.Equals(item))
                {
                    yield return i;
                }
            }

            yield break;
        }

        public IEnumerator<T> GetEnumerator() => new ArrayListOptimizedExecutionTimeEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ReduceCapacity()
        {
            if (Length == 1)
            {
                return;
            }

            var newItems = new T[CurrentCapacity / 2];
            for (var i = 0; i < Length; i++)
            {
                newItems[i] = Items[CalculateCorrectIndex(i)];
            }
            StartIndex = 0;
            Items = newItems;
        }

        private int CalculatePreviousIndexOf(int index)
        {
            return index > 0 
                 ? (index - 1) % Items.Length 
                 : Items.Length - 1;
        }

        private int CalculateNextIndexOf(int index)
        {
            return (index + 1) % Items.Length;
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

        private int CalculateCorrectIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            var correctIndex = index;
            if (index > Length)
            {
                correctIndex = Length;
            }
            correctIndex += StartIndex;
            correctIndex %= Items.Length;
            return correctIndex;
        }
    }
}
