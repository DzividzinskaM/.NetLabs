using System;
using System.Collections;
using System.Collections.Generic;


namespace Collection
{
    public class MyList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        public int Capacity { get; set; }
        public int Count { get => count; }

        private T[] items;   
        private int count;
        private const int expandingValue = 2;   

        public bool IsReadOnly { get => false; }

        public T this[int index]
        { 
            get 
            {   
                if (index < 0 || index > count)
                    throw new ArgumentOutOfRangeException();
                return items[index];
            }
            set 
            { 
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException();
                if (IsReadOnly)
                    throw new NotSupportedException();
                items[index] = value;
            } 
        }

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
            if (IsReadOnly)
                throw new NotSupportedException();
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
            if (IsReadOnly)
                throw new NotSupportedException();
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

        public void CopyTo(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (count > array.Length)
                throw new ArgumentException();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = items[i];
            }
        }

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if(array == null)
                throw new ArgumentNullException();
            if (index < 0 || arrayIndex < 0 || count < 0)
                throw new ArgumentOutOfRangeException();
            if (index >= Count || array.Length - arrayIndex < Count - index)
                throw new ArgumentException();

            while (count != 0)
            {
                array[arrayIndex] = items[index];
                arrayIndex++;
                index++;
                count--;
            }
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            for (int i=0; i<items.Length; i++)
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
            if (IsReadOnly)
                throw new NotSupportedException();
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            if (count == Capacity)
                Expand();

            count++;

            for(int i = count; i>=index; i--)
            {
                items[i + 1] = items[i];
            }
            items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;

        }


        public void Sort(IComparer<T> comparer)
        {
            T temp;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (comparer.Compare(items[i], items[j]) > 0)
                    {
                        temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0; i<count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }







/*        public delegate void AddingHandler(object sender, 
            EventArgs<T> e);
        public event AddingHandler addItem;*/


        public delegate void UpdatingHandler(object sender,
           UpdateEventArgs<T> e);
        public event UpdatingHandler updateItemEvent;

        public void Update(int index, T newItem)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();
            

            if (updateItemEvent != null)
            {
                T oldItem = items[index];
                items[index] = newItem;
                UpdateEventArgs<T> args = new UpdateEventArgs<T>(oldItem, newItem, index);

                updateItemEvent(this, args);
            }
        }

        


        

        /*public void AddEvent(T item, int index = -1)
        {
            addItem = null;
            if (index != -1)
            {
                addItem += checkIndex;
                addItem += checkExpand;
                addItem += AddElement;
                addItem += CountExpanse;

                addItem(this, new EventArgs<T>(item, index));
            }
            else
            {
                addItem += checkExpand;
                addItem += AddElement;
                addItem += CountExpanse;

                addItem(this, new EventArgs<T>(item, count));
            }

        }*/

    }


    public class UpdateEventArgs<T> : EventArgs
    {
        public T OldItem { get; }
        public T NewItem { get; }

        public int Index { get; }

        public UpdateEventArgs(T oldItem, T newItem, int index)
        {
            OldItem = oldItem;
            NewItem = newItem;
            Index = index;
        }
    }

   
}
