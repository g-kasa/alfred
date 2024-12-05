using AlfredLists = Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.Queues
{
    /// <summary>
    /// Implementation of a LIFO queue.
    /// </summary>
    /// <typeparam name="T">
    /// The type of items in the queue.
    /// </typeparam>
    public class Stack<T> : IQueue<T>
    {
        private AlfredLists.IList<T> Items { get; set; }

        /// <summary>
        /// Number of items in the queue.
        /// </summary>
        public int Count => Items.Length;

        public Stack()
        {
            Items = new AlfredLists.ArrayList<T>();
        }
        public Stack(T item)
        {
            Items = new AlfredLists.ArrayList<T>(item);
        }
        public Stack(IEnumerable<T> items)
        {
            Items = new AlfredLists.ArrayList<T>(items);
        }

        /// <summary>
        /// Return the last item in the stack without removing it.
        /// </summary>
        /// <returns>
        /// The last item in the stack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If the stack is empty.
        /// </exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Items[Count - 1];
        }

        /// <summary>
        /// Remove and return the last item in the stack.
        /// </summary>
        /// <returns>
        /// The last item in the stack.
        /// </returns>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return Items.RemoveAt(Count - 1);
        }

        /// <summary>
        /// Push a new item onto the stack.
        /// </summary>
        /// <param name="item">
        /// The item to push onto the stack.
        /// </param>
        public void Push(T item)
        {
            Items.Insert(Count, item);
        }
    }
}
