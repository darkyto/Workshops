namespace HashSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashSet<T> : IEnumerable<T>
    {
        private const float FIXEDPERCENT = 0.75f;

        private int count;
        private int capacity;
        private List<T>[] values;

        public HashSet()
        {
            this.Count = 0;
            this.Capacity = 16;
            this.values = new List<T>[16];
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public void Add(T value)
        {
            if (this.Contains(value))
            {
                return;
            }

            var index = Hash(value);

            if (this.values[index] == null)
            {
                this.values[index] = new List<T>();
            }

            this.values[index].Add(value);
            ++this.Count;

            if (this.Count > (this.Capacity * FIXEDPERCENT))
            {
                this.ResizeAndRead();
            }
        }

        public void Remove(T value)
        {
            if (!this.Contains(value))
            {
                throw new ArgumentException("This value is not in the set");
            }

            var index = Hash(value);

            this.values[index].Remove(value);
        }

        public bool Contains(T value)
        {
            var index = Hash(value);

            if (this.values[index] == null)
            {
                return false;
            }

            return this.values[index].Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var valueList in this.values)
            {
                if (valueList == null)
                {
                    continue;
                }

                foreach (var value in valueList)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeAndRead()
        {
            var oldValues = (List<T>[])this.values.Clone();
            this.Capacity *= 2;
            this.values = new List<T>[this.Capacity];

            foreach (var valueList in oldValues)
            {
                if (valueList != null)
                {
                    foreach (var value in valueList)
                    {
                        this.Add(value);
                    }
                }
            }
        }

        private int Hash(T value)
        {
            var hash = value.GetHashCode();
            if (hash < 0)
            {
                hash *= -1;
            }

            var index = hash;
            index %= this.values.Length;
            return index;
        }
    }
}
