namespace ExamTask.MostCommon
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// http://bgcoder.com/Contests/Practice/Index/15#1
    /// You are given a list of N humans with their characteristics 
    /// (first name, last name, year of birth, eye color, hair color and height in cm.). 
    /// Find their most common characteristics.
    /// 
    /// Input
    /// The input data should be read from the console.
    /// The number N will be given on the first line.
    /// On each of the next N lines you will be given the 6 human characteristics in the following format:
    /// "{first_name} {last_name}, {year_of_birth}, {eye_color}, {hair_color}, {height}". 
    /// Note that there is a space between the first and the last name and after each comma.
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            ReadInput();
        }

        public static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            //(first name, last name, year of birth, eye color, hair color and height in cm.). 
            Dictionary<string, int> firstNames = new Dictionary<string, int>();
            Dictionary<string, int> lastNames = new Dictionary<string, int>();
            Dictionary<string, int> years = new Dictionary<string, int>();
            Dictionary<string, int> eyes = new Dictionary<string, int>();
            Dictionary<string, int> hairs = new Dictionary<string, int>();
            Dictionary<string, int> heights = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] characteristics = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                AddElementToDictionary(characteristics[0], firstNames);
                AddElementToDictionary(characteristics[1], lastNames);
                AddElementToDictionary(characteristics[2], years);
                AddElementToDictionary(characteristics[3], eyes);
                AddElementToDictionary(characteristics[4], hairs);
                AddElementToDictionary(characteristics[5], heights);
            }

            Console.WriteLine(SearchElement(firstNames));
            Console.WriteLine(SearchElement(lastNames));
            Console.WriteLine(SearchElement(years));
            Console.WriteLine(SearchElement(eyes));
            Console.WriteLine(SearchElement(hairs));
            Console.WriteLine(SearchElement(heights));
        }

        public static void AddElementToDictionary(string key, Dictionary<string, int> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 1);
            }
            else
            {
                dictionary[key]++;
            }
        }

        private static string SearchElement(Dictionary<string, int> dictionary)
        {
            string result = string.Empty;
            int max = int.MinValue;

            foreach (var item in dictionary)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    result = item.Key;
                }

                if (item.Value == max)
                {
                    if (result.CompareTo(item.Key) > 0)
                    {
                        result = item.Key;
                    }
                }
            }

            return result;
        }
    }
}
