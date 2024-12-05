namespace Alfred.DataStructures.Queues
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Number of items in the queue.
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Push a new item onto the queue.
        /// </summary>
        /// <param name="item">
        /// The item to push onto the queue.
        /// </param>
        void Push(T item);
        /// <summary>
        /// Remove and return the first item in the queue.
        /// </summary>
        /// <returns>
        /// The first item in the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If the queue is empty.
        /// </exception>
        T Pop();
        /// <summary>
        /// Return the first item in the queue without removing it.
        /// </summary>
        /// <returns>
        /// The first item in the queue.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If the queue is empty.
        /// </exception>
        T Peek();
    }
}
