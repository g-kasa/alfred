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

        public ArrayListOptimizedExecutionTime()
            : this(initialCapacity: 8)
        { }
        public ArrayListOptimizedExecutionTime(int initialCapacity)
        {
            Items = new T[initialCapacity];
            StartIndex = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return Items[CalculateCorrectIndex(index)];
            }
        }

        public void Insert(int index, T value)
        {
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
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the collection.
        /// </exception>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

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

        public IEnumerator<T> GetEnumerator() => new ArrayListOptimizedExecutionTimeEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ReduceCapacity()
        {
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
            var newItems = new T[Items.Length * 2];
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
