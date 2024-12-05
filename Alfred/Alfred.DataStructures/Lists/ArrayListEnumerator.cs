using System.Collections;

namespace Alfred.DataStructures.Lists
{
    public class ArrayListEnumerator<T>(ArrayList<T> list) : IEnumerator<T>
    {
        private ArrayList<T> List { get; } = list;
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
