namespace _02.Towns
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var lineParts = line.Split(' ');
                int num = int.Parse(lineParts[0]);
                nums.Add(num);
            }

            var res = Solve(nums);
            Console.WriteLine(res);
        }

        public static int Solve(List<int> nums)
        {
            // max increasing subsequences left-right
            var leftToRight = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                var maxLenght = 0;
                for (int j = 0; j < i ; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLenght = Math.Max(maxLenght, leftToRight[j]);
                    }
                }

                leftToRight[i] = maxLenght + 1;
            }

            // max increasing subsequences right=left
            var rightToLeft = new int[nums.Count];
            for (int i = nums.Count - 1; i > 0; i--)
            {
                var maxLenght = 0;
                for (int j = nums.Count - 1; j > i; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        maxLenght = Math.Max(maxLenght, rightToLeft[j]);
                    }
                }

                rightToLeft[i] = maxLenght + 1;
            }
            // combine both and find max
            var maxPath = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                var path = leftToRight[i] + rightToLeft[i] - 1;
                maxPath = Math.Max(maxPath, path);
            }

            return maxPath;
        }
    }
}
