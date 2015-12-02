namespace ExamTask.RiskWin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string startCombination =Console.ReadLine();
            string endCombination = Console.ReadLine();

            List<string> forbiddenCombination = new List<string>(); // for the GREEDY answer
            HashSet<string> visited = new HashSet<string>(); // for the BFS answer;

            for (int i = 0; i < forbiddenCombination.Count; i++)
            {
                string comb = Console.ReadLine();
                // forbiddenCombination.Add(comb);
                visited.Add(comb);
            }

            // bfs logic follows..
            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(startCombination, 0));
            visited.Add(startCombination);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (current.Item1 == endCombination)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                // press right
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }

                    // TODO: Generate new node
                    var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    string newNode = sb.ToString();
                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                    }
                }

                // press left
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit--;
                    if (digit == -1)
                    {
                        digit = 9;
                    }

                    // TODO: Generate new node
                    var sb = new StringBuilder(current.Item1);
                    sb[i] = (char)(digit + '0');
                    string newNode = sb.ToString();
                    if (!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                    }
                }
            }

            Console.WriteLine(-1);

            //// GREEDY this is naive method but still gets points in bgcoder.com
            //var count = 0;
            //for (int i = 0; i < startCombination.Length; i++)
            //{
            //    int startDigit = startCombination[i] - '0';
            //    int endDigit = endCombination[i] - '0';

            //    count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));
            //}

            //Console.WriteLine(count);
        }
    }
}
