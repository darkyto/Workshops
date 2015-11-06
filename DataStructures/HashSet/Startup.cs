namespace HashSet
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < 1000; i++)
            {
                set.Add("5" + i);
                set.Add("6" + i);
                set.Add("10" + i);
                set.Add("16" + i);
                set.Add("2" + i);
            }

            set.Add("John");
            set.Add("John");

            Console.WriteLine(set.Contains("12"));
            Console.WriteLine(set.Contains("50"));
            Console.WriteLine(set.Contains("John"));

            set.Remove("John");
            Console.WriteLine(set.Contains("John"));
        }
    }
}
