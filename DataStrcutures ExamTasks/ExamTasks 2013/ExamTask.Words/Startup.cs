namespace ExamTask.Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// http://www.math.bas.bg/infos/files/2012-12-13-task6.pdf
    /// Даден е текст на латиница и списък с думи (на латиница). Да се напише програма, която намира за
    /// всяка входна дума броя уникални думи в текста, които съдържат всяка една от буквите на
    /// съответната входна дума.
    /// За дума в текста се счита всяка последователност от съседни латински букви, оградени от
    /// разделители или начало / край на текст.За разделители се считат всички символи, които не са
    ///  латински букви.Разлика между главни и малки букви не се прави. 
    /// bgcoder 100/100
    /// </summary>
    public class Startup
    {
        private static Dictionary<char, HashSet<string>> allWordsByChar = new Dictionary<char, HashSet<string>>();

        public static void Main(string[] args)
        {
            InitDict();
            ReadInputText();

            //foreach (var item in allWordsByChar)
            //{
            //    Console.WriteLine("KEY LETTER [{0}] : ", item.Key);
            //    foreach (var word in item.Value)
            //    {
            //        Console.Write(word + " ");
            //    }
            //    Console.WriteLine(new string('-', 40));
            //}

            Solve();
        }

        /// <summary>
        /// create dictionary(char, HSet) and push the letters from alphabet inside
        /// </summary>
        public static void InitDict()
        {
            for (char i = 'a'; i <= 'z'; i++)
            {
                allWordsByChar[i] = new HashSet<string>();
            }
        }

        /// <summary>
        /// Add word in dictionary for each unique letter from the alphabet
        /// </summary>
        /// <param name="word"></param>
        public static void AddWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                allWordsByChar[word[i]].Add(word);
            }
        }

        public static void ReadInputText()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                var sbWord = new StringBuilder();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] >= 'a' && line[j] <= 'z')
                    {
                        sbWord.Append(line[j]);
                    }
                    else if (line[j] >= 'A' && line[j] <= 'Z')
                    {
                        sbWord.Append((char)(line[j] - 'A' + 'a'));
                    }
                    else if (sbWord.Length > 0)
                    {
                        AddWord(sbWord.ToString());
                        sbWord.Clear();
                    }
                }

                if (sbWord.Length > 0)
                {
                    AddWord(sbWord.ToString());
                    sbWord.Clear();
                }
            }
        }

        public static void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string wordToLower = word.ToLower();

                // create new hashset with the text words containt wordToLower[0]
                HashSet<string> current = new HashSet<string>(allWordsByChar[wordToLower[0]]);

                for (int j = 0; j < wordToLower.Length; j++)
                {
                    // Modifies the current HashSet<T> object to contain only elements that are present 
                    // in that object and in the specified collection.
                    current.IntersectWith(allWordsByChar[wordToLower[j]]);
                }

                Console.WriteLine(word + " -> " + current.Count);
            }
        }
    }
}
