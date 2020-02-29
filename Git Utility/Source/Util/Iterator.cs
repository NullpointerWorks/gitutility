using System.Collections.Generic;

namespace GitUtility.Util
{
    /// <summary>
    /// iterator pattern to protect the order of objects in a list/array
    /// </summary>
    /// <typeparam name="T">List class type</typeparam>
    public class Iterator<T>
    {
        private int index = 0;
        private int size = 0;
        private List<T> list;
        public Iterator(List<T> l)
        {
            list = l;
            size = l.Count;
        }

        public bool HasNext()
        {
            return index < size;
        }

        public T GetNext()
        {
            return list[index++];
        }

        public void Reset()
        {
            index = 0;
        }

        public void Dispose()
        {
            list = null;
        }
    }
}
