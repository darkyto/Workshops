namespace _03.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var nums = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int k = int.Parse(Console.ReadLine());

            var answer = Solve(nums, k);

            Console.WriteLine(answer);
        }

        private static int Solve(int[] nums, int k)
        {
            var visited = new Dictionary<int, int>();

            var queue = new Queue<int[]>();
            queue.Enqueue(nums);
            visited.Add(GetHashCode(nums), 0);

            while (queue.Count > 0)
            {
                var currentPermutation = queue.Dequeue();

                if (IsSorted(currentPermutation))
                {

                    return visited[GetHashCode(currentPermutation)];
                }

                for (int i = 0; i < nums.Length - k; i++)
                {
                    var desc = currentPermutation.Clone() as int[];
                    Array.Reverse(desc, i, k);

                    if (!visited.ContainsKey(GetHashCode(desc)))
                    {
                        visited.Add(GetHashCode(desc), visited[GetHashCode(currentPermutation)] + 1);
                        queue.Enqueue(desc);
                    }
                }
            }

            return -1;
        }

        private static bool IsSorted(int[] perm)
        {
            for (int i = 1; i < perm.Length; i++)
            {
                if (perm[i] < perm[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetHashCode(int[] nums)
        {
            int hash = 0;
            foreach (var item in nums)
            {
                hash *= 8;
                hash += item;
            }

            return hash;
        }
    }
}
