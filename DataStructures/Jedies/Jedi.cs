using System.Collections.Generic;

namespace Jedies
{
    using System;

    public class Jedi : IComparable<Jedi>
    {
        private static Dictionary<char, int> priority = new Dictionary<char, int> {{'m', 1}, {'k', 2}, {'p', 3},};
        private string name;
        private int index;

        public Jedi(string name, int index)
        {
            this.name = name;
            this.index = index;
        }

        public int CompareTo(Jedi other)
        {
            var thisType = this.name[0];
            var otherType = other.name[0];
            var thisPriority = priority[thisType];
            var otherPriority = priority[otherType];
            if (thisPriority == otherPriority)
            {
                return this.index.CompareTo(other.index);
            }

            return thisPriority.CompareTo(otherPriority);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}