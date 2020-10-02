using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class MyList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        public int Capacity { get; set; }
        public int Count { get => count; }

        private T[] items;     
        private int count;
        private const int expandingValue = 2;
       


        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get => items[index]; set => throw new NotImplementedException(); }

        public MyList()
        {
            Capacity = expandingValue;
            count = 0;
            items = new T[Capacity];
        }

        public MyList(int capacity)
        {
            Capacity = capacity;
            count = 0;
            items = new T[Capacity];     
        }

        public void Add(T item)
        {
            if (count == Capacity)
                Expand();
            items[count] = item;
            count++;

        }

        private void Expand()
        {
            Capacity = expandingValue * count;
            T[] newItems = new T[Capacity];
            for(int i=0; i < count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            for(int i=0; i< count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
           
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException(); 

            
            for(int i=arrayIndex, j=0; i < array.Length; i++, j++)
            {
                array[i] = items[j];
            }
           
        }

        public bool Remove(T item)
        {
            for(int i=0; i<items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    count--;
                    for(int j=i; j<items.Length-1; j++)
                    {
                        items[j] = items[j+1];
                    }
                    return true;
                }
            }
            return false;
        }
            
     
        public int IndexOf(T item)
        {
            for(int i=0; i<count; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (count == Capacity)
                Expand();

            for(int i = items.Length+ 1; i>=index; i--)
            {
                items[i + 1] = items[i];
            }
            items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
