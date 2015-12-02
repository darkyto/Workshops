namespace _01.Strings
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            //MоckInput();

            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            int maxLenght = Solve(input1, input2);
            Console.WriteLine(maxLenght);
        }

        private static int Solve(string string1, string string2)
        {
            int left = 0;
            int right = Math.Min(string1.Length, string2.Length) + 1;

            Hash.ComputePowers(Math.Min(string1.Length, string2.Length));

            while (left < right)
            {
                int middle = (left + right) / 2;
                bool isFound = Check(string1, string2, middle);

                if (isFound)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return right - 1;
        }

        private static bool Check(string str1, string str2, int length)
        {
            var hash1 = new Hash(str1.Substring(0, length));

            HashSet<ulong> hashes = new HashSet<ulong>();
            HashSet<ulong> hashes2 = new HashSet<ulong>();
            HashSet<ulong> hashes3 = new HashSet<ulong>();

            hashes.Add(hash1.Value);
            hashes2.Add(hash1.Value2);
            hashes3.Add(hash1.Value3);

            for (int i = 0; i < str1.Length - length; i++)
            {
                hash1.Add(str1[length + i]);
                hash1.Remove(str1[i], length);

                hashes.Add(hash1.Value);
                hashes2.Add(hash1.Value2);
                hashes3.Add(hash1.Value3);
            }

            var hash2 = new Hash(str2.Substring(0, length));
            var hash3 = new Hash(str2.Substring(0, length));

            if (hashes.Contains(hash2.Value) && hashes2.Contains(hash2.Value2) && hashes3.Contains(hash3.Value3))
            {
                return true;
            }

            for (int i = 0; i < str2.Length - length; i++)
            {
                hash2.Add(str2[length + i]);
                hash2.Remove(str2[i], length);
                hash3.Add(str2[length + i]);
                hash3.Remove(str2[i], length);
                if (hashes.Contains(hash2.Value) && hashes2.Contains(hash2.Value2) && hashes3.Contains(hash3.Value3))
                {
                    return true;
                }
            }

            return false;
        }

        public static void MоckInput()
        {
            string input = @"-=input=- 
put-=23";
            Console.SetIn(new StringReader(input));
        }
    }

    public class Hash
    {
        private const ulong BASE = 127;
        private const ulong BASE2 = 257;
        private const ulong BASE3 = 263;
        private const ulong MOD = 1000000033;

        private static ulong[] powers;
        private static ulong[] powers2;
        private static ulong[] powers3;

        public static void ComputePowers(int n)
        {
            powers = new ulong[n + 1];
            powers2 = new ulong[n + 1];
            powers3 = new ulong[n + 1];
            powers[0] = 1;
            powers2[0] = 1;
            powers3[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers[i + 1] = powers[i] * BASE % MOD;
                powers2[i + 1] = powers2[i] * BASE2 % MOD;
                powers3[i + 1] = powers3[i] * BASE3 % MOD;
            }
        }

        public ulong Value { get; private set; }
        public ulong Value2 { get; private set; }
        public ulong Value3 { get; private set; }

        public Hash(string str)
        {
            this.Value = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value =
                (this.Value * BASE + c)
                          % MOD;

            this.Value2 =
                (this.Value2 * BASE2 + c)
                          % MOD;

            this.Value3 =
                (this.Value3 * BASE3 + c)
                          % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value = (MOD +
              this.Value - powers[n] * c % MOD)
                    % MOD;

            this.Value2 = (MOD +
              this.Value2 - powers2[n] * c % MOD)
                    % MOD;

            this.Value3 = (MOD +
              this.Value3 - powers3[n] * c % MOD)
                    % MOD;
        }
    }
}


