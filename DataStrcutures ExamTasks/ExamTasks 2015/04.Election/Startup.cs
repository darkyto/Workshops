namespace _04.Election
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }

            //var count = 0;
            //for (int i = 1; i < Math.Pow(2, n); i++)
            //{
            //    if (k >= CalculateSum(i, nums))
            //    {
            //        count++;
            //    }
            //}
            //Console.WriteLine(count);
            var res = GetmNumberOfSubsets(nums, k);
            var count = 0;
            foreach (var item in res)
            {
                if (item == 1)
                {
                    count++;
                }

                if (item == 2)
                {
                    count += 2;
                }

                if (item == 4)
                {
                    count += 4;
                }
            }
            Console.WriteLine(count);
        }

        public static long CalculateSum(int subSet, long[] nums)
        {
            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int bit = (subSet & (1 << i)) >> i;
                sum += nums[i] * bit;
            }
            return sum;
        }

        private static int[] GetmNumberOfSubsets(int[] numbers, int sum)
        {
            var count = 0;
            int[] dp = new int[sum + 1];
            dp[0] = 1;
            int currentSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                for (int j = Math.Min(sum, currentSum); j >= numbers[i]; j--)
                {
                    dp[j] += dp[j - numbers[i]];
                }
            }

            return dp;
        }
    }
}
