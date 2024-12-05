using System.Collections;

namespace Alfred.DataStructures.Lists
{
    public class LinkedListEnumerator<T>(LinkedList<T> list) : IEnumerator<T>
    {
        private LinkedList<T> List { get; } = list;
        private int CurrentIndex { get; set; } = -1;

        public T Current => List[CurrentIndex];
        object IEnumerator.Current => Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if (List.Length == 0 || CurrentIndex >= List.Length - 1)
            {
                return false;
            }
            CurrentIndex++;
            return true;
        }

        public void Reset()
        {
            CurrentIndex = -1;
        }
    }
}
