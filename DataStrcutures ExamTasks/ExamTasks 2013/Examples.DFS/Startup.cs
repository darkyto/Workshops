namespace Examples.DFS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static int maxSum = int.MinValue;
        static int totalSum = 0;

        static int[][] graph =
                            {
                            new [] { 1, 6, 7 },
                            new [] { 0, 2, 5 },
                            new [] { 1, 3, 4 },
                            new [] { 2 },
                            new [] { 2 },
                            new [] { 1 },
                            new [] { 0 },
                            new [] { 0, 8, 11 },
                            new [] { 7, 9, 10 },
                            new [] { 8 },
                            new [] { 8 },
                            new [] { 7 },
                            };

        static bool[] visited = new bool[graph.Length];

        static bool[] visitedTotalSum = new bool[graph.Length];

        static bool[] visitedMinSum = new bool[graph.Length];

        public static void Main(string[] args)
        {
            int node = graph[0][0];

            DfsRecursiveMaxPathSum(5, 0, 1);
            Console.WriteLine("Max path (both directions) : " + maxSum);

            DfsRecursiveTotalTreeSum(5);
            Console.WriteLine("total sum of all members : " + totalSum);
        }

        internal static void DfsRecursiveMaxPathSum(int node, int currentSum, int depth)
        {
            currentSum += node;
            if (!visited[node])
            {
                depth++;
            }
            visited[node] = true;


            Console.WriteLine(new string('=', depth*3) +  node);

            foreach (int neighbor in graph[node])
            {
                if (visited[neighbor])
                {
                    continue;
                }

                DfsRecursiveMaxPathSum(neighbor, currentSum, depth);
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        internal static void DfsRecursiveTotalTreeSum(int node)
        {
            if (!visitedTotalSum[node])
            {
                totalSum += node;
            }
            visitedTotalSum[node] = true;

            foreach (int neighbor in graph[node])
            {
                if (visitedTotalSum[neighbor])
                {
                    continue;
                }

                DfsRecursiveTotalTreeSum(neighbor);
            }
        }
    }
}
