namespace Alfred.DataStructures.Lists
{
    public class ArrayList<T>
    {
        /// <summary>
        /// Collection of items.
        /// </summary>
        private T[] Items { get; set; }
        /// <summary>
        /// The minimum capacity of the collection.
        /// </summary>
        private int MinCapacity { get; set; }

        /// <summary>
        /// Number of items in the collection.
        /// </summary>
        public int Length { get; private set; }

        public ArrayList()
            : this(8)
        { }

        public ArrayList(int minCapacity)
        {
            MinCapacity = minCapacity;
            Items = new T[minCapacity];
            Length = 0;
        }

        /// <summary>
        /// Indexer for the collection.
        /// </summary>
        /// <paramref name="index">The index of the item to get or set.</paramref>
        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
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
        public T RemoveAt(int index)
        {
            var correctIndex = CalculateCorrectIndex(index);
            var value = Items[correctIndex];
            ShiftLeft(correctIndex);
            Length--;

            return value;
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
            for (var i = index; i < Length; i++)
            {
                Items[i] = Items[i + 1];
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
            var correctIndex = index;
            if (correctIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (correctIndex > Length)
            {
                correctIndex = Length;
            }
            return correctIndex;
        }
    }
}
