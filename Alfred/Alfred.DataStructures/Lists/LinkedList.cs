using System.Collections;

namespace Alfred.DataStructures.Lists
{
    internal class LinkedListNode<TItem>
    {
        internal TItem Item { get; set; }
        internal LinkedListNode<TItem>? Next { get; set; } // Allow Next to be null

        internal LinkedListNode(TItem item, LinkedListNode<TItem>? next) // Allow next to be null
        {
            Item = item;
            Next = next;
        }
        internal LinkedListNode(TItem item)
            : this(item, null)
        { }
    }

    /// <summary>
    /// A list of items.
    /// </summary>
    /// <typeparam name="T">
    /// The type of items in the list.
    /// </typeparam>
    /// <remarks>
    /// This is a barebones singly linked list implementation.
    /// </remarks>
    public class LinkedList<T> : IList<T>
    {
        private LinkedListNode<T>? _head;
        private LinkedListNode<T>? _tail;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="LinkedList{T}"/> class.
        /// </summary>
        public LinkedList()
        {
            _head = null;
            _tail = null;
            Length = 0;
        }
        /// <summary>
        /// Creates a new instance of the <see cref="LinkedList{T}"/> class.
        /// </summary>
        /// <param name="item">
        /// The first item in the list.
        /// </param>
        public LinkedList(T item)
            : this()
        {
            Insert(0, item);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="LinkedList{T}"/> class.
        /// </summary>
        /// <param name="items">
        /// The items to add to the list.
        /// </param>
        public LinkedList(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
            {
                Insert(Length, item);
            }
        }

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index of the item to get. Index is 0-based.
        /// </param>
        /// <returns>
        /// The value at the specified index.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the list.
        /// </exception>
        /// <remarks>
        /// Time Complexity: O(n).
        /// </remarks>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                var current = _head;
                for (var i = 0; i < index; i++)
                {
                    current = current!.Next;
                }
                return current!.Item;
            }
        }

        /// <summary>
        /// Inserts a value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index at which to insert the value. The index is 0-based.
        /// </param>
        /// <param name="value">
        /// The value to insert.
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is less than 0.
        /// </exception>
        /// <remarks>
        /// Time Complexity: O(n)
        /// </remarks>
        public void Insert(int index, T value)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (index == 0 || _head == null)
            {
                _head = new LinkedListNode<T>(value, _head);
                _tail = _head;
            }
            else if (index >= Length)
            {
                _tail!.Next = new LinkedListNode<T>(value);
                _tail = _tail.Next;
            }
            else 
            {
                var current = _head;
                var i = 0;
                while (i < index - 1 && current.Next != null)
                {
                    current = current.Next;
                    i++;
                }
                current!.Next = new LinkedListNode<T>(value, current.Next);
            }

            Length++;
        }

        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <param name="index">
        /// The index of the value to remove. The index is 0-based.
        /// </param>
        /// <returns>
        /// The value that was removed.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is less than 0 or greater than or equal to the length of the list.
        /// </exception>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            T value;
            if (index == 0)
            {
                value = _head!.Item;
                _head = _head.Next;
            }
            else
            {
                var previous = _head;
                var current = previous!.Next;
                for (var i = 1; i < index; i++)
                {
                    previous = current;
                    current = current!.Next;
                }
                // current is the node to remove
                if (current!.Next == null)
                {
                    _tail = previous;
                }
                value = current!.Item;
                previous!.Next = current.Next;
            }
            Length--;
            if (Length == 0)
            {
                _tail = null;
            }

            return value;
        }

        public IEnumerator<T> GetEnumerator() => new LinkedListEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
