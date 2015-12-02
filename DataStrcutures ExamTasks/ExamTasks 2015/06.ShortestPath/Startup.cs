using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ShortestPath
{
    public class Startup
    {
        private static char[] map;
        private static SortedSet<string> results = new SortedSet<string>();

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            map = input.ToCharArray();

            Find(0);

            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                Console.WriteLine(item.ToUpper());
            }
        }

        public static void Find(int index)
        {
            if (index == map.Length)
            {
                results.Add(new string(map));
            }
            else if (map[index] != '*')
            {
                Find(index + 1);
            }
            else
            {
                map[index] = 'R';
                Find(index + 1);
                map[index] = 'L';
                Find(index + 1);
                map[index] = 's';
                Find(index + 1);
                map[index] = '*';
            }
        }
    }
}
