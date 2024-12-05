using AlfredLists = Alfred.DataStructures.Lists;

namespace Alfred.DataStructures.Queues
{
    public class PriorityQueue<TPriority, TValue> : IPriorityQueue<TPriority, TValue>
            where TPriority : IComparable<TPriority>
    {
        private AlfredLists.IList<Tuple<TPriority, TValue>> Items { get; }
        private PriorityType PriorityType { get; }

        public int Count => Items.Length;

        public PriorityQueue(PriorityType priorityType)
        {
            Items = new AlfredLists.ArrayList<Tuple<TPriority, TValue>>();
        }

        public Tuple<TPriority, TValue> Peek()
        {
            throw new NotImplementedException();
        }

        public Tuple<TPriority, TValue> Pop()
        {
            var result = Items[0];
            Items[0] = Items[Count - 1];
            Items.RemoveAt(Count - 1);
            int currentItemIndex = 0;
            do
            {
                int leftChildIndex = 2 * currentItemIndex + 1;
                if (leftChildIndex >= Count)
                {
                    break;
                }
                int rightChildIndex = 2 * currentItemIndex + 2;
                int indexToSwapWith = currentItemIndex;
                if (PriorityType == PriorityType.MaxFirst)
                {
                    if (rightChildIndex < Count)
                    {
                        indexToSwapWith = Items[leftChildIndex].Item1.CompareTo(Items[rightChildIndex].Item1) > 0 ? leftChildIndex : rightChildIndex;
                    }
                    else
                    {
                        indexToSwapWith = leftChildIndex;
                    }

                    if (Items[currentItemIndex].Item1.CompareTo(Items[indexToSwapWith].Item1) >= 0)
                    {
                        break;
                    }
                }
                else
                {
                    if (rightChildIndex < Count)
                    {
                        indexToSwapWith = Items[leftChildIndex].Item1.CompareTo(Items[rightChildIndex].Item1) < 0 ? leftChildIndex : rightChildIndex;
                    }
                    else
                    {
                        indexToSwapWith = leftChildIndex;
                    }

                    if (Items[currentItemIndex].Item1.CompareTo(Items[indexToSwapWith].Item1) <= 0)
                    {
                        break;
                    }
                }
                var temp = Items[currentItemIndex];
                Items[currentItemIndex] = Items[indexToSwapWith];
                Items[indexToSwapWith] = temp;
                currentItemIndex = indexToSwapWith;
            } while (currentItemIndex <= Count);

            return result;
        }

        /// <summary>
        /// Pushes an item into the queue.
        /// </summary>
        /// <param name="item">
        /// The item to push into the queue.
        /// </param>
        /// <remarks>
        /// Time complexity: O(log n)
        /// </remarks>
        public void Push(Tuple<TPriority, TValue> item)
        {
            Items.Insert(Count, item);
            int currentItemIndex = Count - 1;
            while (currentItemIndex > 0)
            {
                int parentIndex = (currentItemIndex - 1) / 2;
                if ((PriorityType == PriorityType.MaxFirst && Items[parentIndex].Item1.CompareTo(Items[currentItemIndex].Item1) > 0)
                    || (PriorityType == PriorityType.MinFirst && Items[parentIndex].Item1.CompareTo(Items[currentItemIndex].Item1) < 0))
                {
                    break;
                }
                Items[currentItemIndex] = Items[parentIndex];
                Items[parentIndex] = item;
                currentItemIndex = parentIndex;
            }
        }
    }
}
