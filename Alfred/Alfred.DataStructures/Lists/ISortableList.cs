namespace Alfred.DataStructures.Lists
{
    public interface ISortableList<T> : IList<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the list.
        /// </summary>
        /// <remarks>
        /// This method is meant to sort the list in place. The sorting algorithm used is up to the implementer. In the implementation of this method, the implementer should consider the performance implications of the sorting algorithm used.
        /// </remarks>
        void Sort();
        /// <summary>
        /// Sorts the list using the bubble sort algorithm.
        /// </summary>
        void BubbleSort();
        /// <summary>
        /// Sorts the list using the selection sort algorithm.
        /// </summary>
        void SelectionSort();
        /// <summary>
        /// Sorts the list using the insertion sort algorithm.
        /// </summary>
        void InsertionSort();
        /// <summary>
        /// Sorts the list using the quicksort algorithm.
        /// </summary>
        void QuickSort();
        /// <summary>
        /// Sorts the list using the mergesort algorithm.
        /// </summary>
        void MergeSort();
        /// <summary>
        /// Sorts the list using the heapsort algorithm.
        /// </summary>
        void HeapSort();
    }
}
