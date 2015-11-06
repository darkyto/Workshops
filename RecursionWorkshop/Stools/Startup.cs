namespace Stools
{
    using System;

    /// <summary>
    /// https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/blob/master/workshops/2015-11-06-recursion-and-data-structures/Stools/README.md
    /// </summary>
    public class Startup
    {
        private static Stool[] stools;

        private static int n;

        private static int[,,] memo;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            stools = new Stool[n];

            memo = new int[1 << n, n, 3];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                stools[i] = new Stool(
                    int.Parse(line[0]), 
                    int.Parse(line[1]), 
                    int.Parse(line[2]));
            }

            int res = 0;

            for (int i = 0; i < n; i++)
            {
                res = Math.Max(res, MaxHeight((1 << n) - 1, i, 0));
                res = Math.Max(res, MaxHeight((1 << n) - 1, i, 1));
                res = Math.Max(res, MaxHeight((1 << n) - 1, i, 2));
            }
          
            Console.WriteLine(res);
        }

        // side x = 0 ; side y = 1; side x = 2;
        public static int MaxHeight(int used, int top, int side)
        {
            if (memo[used, top, side] != 0)
            {
                return memo[used, top, side];
            }

            if (used == (1 << top))
            {
                if (side == 0)
                {
                    return stools[top].X;
                }

                if (side == 1)
                {
                    return stools[top].Y;
                }

                if (side == 2)
                {
                    return stools[top].Z;
                }
            }

            // all stools without the TOP
            int fromStools = used ^ (1 << top);

            int sideX = (side == 0) ? stools[top].Y : stools[top].X;

            int sideY = (side == 2) ? stools[top].Y : stools[top].Z;

            int sideH = stools[top].X + stools[top].Y + stools[top].Z - sideX - sideY;

            var res = sideH;

            for (int i = 0; i < n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {
                    // stools[i] == 0
                    if ((stools[i].Y >= sideX && stools[i].Z >= sideY) ||
                        (stools[i].Y >= sideY && stools[i].Z >= sideX))
                    {
                        res = Math.Max(res, MaxHeight(fromStools, i, 0) + sideH);
                    }

                    // check if it is a cube
                    if (stools[i].X == stools[i].Y && stools[i].Z == stools[i].Y)
                    {
                        continue;
                    }

                    // stools[i] == 1
                    if ((stools[i].X >= sideX && stools[i].Z >= sideY) ||
                        (stools[i].X >= sideY && stools[i].Z >= sideX))
                    {
                        res = Math.Max(res, MaxHeight(fromStools, i, 1) + sideH);
                    }

                    // stools[i] == 2
                    if ((stools[i].X >= sideX && stools[i].Y >= sideY) ||
                        (stools[i].X >= sideY && stools[i].Y >= sideX))
                    {
                        res = Math.Max(res, MaxHeight(fromStools, i, 2) + sideH);
                    }
                }
            }
            memo[used, top, side] = res;
            return res;
        }
    }

    public class Stool
    {
        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y{ get; set; }

        public int Z { get; set; }
    }
}
