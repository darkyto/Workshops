namespace Jedies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
//            string input = @"2
//m4 p1 p7 m3 m2 k1 k4 k2 k3 p4";

//            StringReader reader = new StringReader(input);

//            Console.SetIn(reader);

            var count = int.Parse(Console.ReadLine());

            var jedi = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = WithQueues(jedi);

            Console.WriteLine(result);
        }

        private static string WithQueues(string[] jedi)
        {
            var master = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();

            foreach (var j in jedi)
            {
                switch (j[0])
                {
                    case 'm':
                        master.Enqueue(j);
                        break;
                    case 'k':
                        knights.Enqueue(j);
                        break;
                    case 'p':
                        padawans.Enqueue(j);
                        break;
                }
            }

            var sb = new StringBuilder();

            while (master.Count > 0)
            {
                sb.Append(master.Dequeue() + " ");
            }

            while (knights.Count > 0)
            {
                sb.Append(knights.Dequeue() + " ");
            }

            while (padawans.Count > 0)
            {
                sb.Append(padawans.Dequeue() + " ");
            }

            return sb.ToString();
        }
    }
}
