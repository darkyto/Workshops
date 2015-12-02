using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine(rand.Next(0, 6));


            //var rand = new Random();
            //if (rand.Next(0, 10) <= 5)
            //{
            //    Console.WriteLine(5);
            //}
            //else
            //{
            //    Console.WriteLine(1);
            //}
        }
    }
}
