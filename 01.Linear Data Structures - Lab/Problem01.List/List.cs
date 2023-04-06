namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.CheckIfIndexIsValid(index);
                return items[index];
            }
            set
            {
                this.CheckIfIndexIsValid(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.CheckIfNeedsToExtend();

            items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.CheckIfIndexIsValid(index);
            this.CheckIfNeedsToExtend();
            
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.CheckIfIndexIsValid(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private T[] Extend()
        {
            var copyArr = new T[this.Count * 2];
            Array.Copy(this.items, copyArr, this.items.Length);
            return copyArr;

        }

        private void CheckIfNeedsToExtend()
        {
            if (this.Count == this.items.Length)
            {
                this.items = this.Extend();
            }
        }

        private void CheckIfIndexIsValid(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }


    }
}