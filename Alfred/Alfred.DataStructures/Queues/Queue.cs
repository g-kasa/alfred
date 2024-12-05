using AlfredLists = Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.Queues
{
    /// <summary>
    /// Implementation of a FIFO queue.
    /// </summary>
    /// <typeparam name="T">
    /// The type of items in the queue.
    /// </typeparam>
    public class Queue<T>
    {
        private AlfredLists.IList<T> Items { get; set; }

        /// <summary>
        /// Number of items in the queue.
        /// </summary>
        public int Count => Items.Length;

        public Queue()
        {
            Items = new AlfredLists.LinkedList<T>();
        }
        public Queue(T item)
        {
            Items = new AlfredLists.LinkedList<T>(item);
        }
        public Queue(IEnumerable<T> items)
        {
            Items = new AlfredLists.LinkedList<T>(items);
        }

        /// <summary>
        /// Push a new item onto the queue.
        /// </summary>
        /// <param name="item">
        /// The item to push onto the queue.
        /// </param>
        public void Push(T item)
        {
            Items.Insert(Count, item);
        }

        /// <summary>
        /// Remove and return the first item in the queue.
        /// </summary>
        /// <returns>
        /// The first item in the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If the queue is empty.
        /// </exception>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            var item = Items.RemoveAt(0);
            return item;
        }

        /// <summary>
        /// Return the first item in the queue without removing it.
        /// </summary>
        /// <returns>
        /// The first item in the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If the queue is empty.
        /// </exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return Items[0];
        }
    }
}
