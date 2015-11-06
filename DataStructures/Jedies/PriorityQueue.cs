namespace Jedies
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private SortedSet<T> values;

        public PriorityQueue()
        {
            this.values = new SortedSet<T>();
        }

        public int Count
        {
            get { return this.Count; }
        }

        public void Enqueue(Jedi jedi)
        {
             // todo            
        }

        public void Dequeue(T value)
        {
            // todo
        }
    }

}
