namespace RecursionWorkshop
{
    using System;

    /// <summary>
    /// https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/blob/master/workshops/2015-11-06-recursion-and-data-structures/Fibonacci/README.md
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var aMatrix = new FibMatrix(); // the initial fibonachi matrix 1, 1, 1, 0

            Console.WriteLine(PowModeFibMatrix(aMatrix, n).Matrix[0, 1]);
        }

        public static FibMatrix PowModeFibMatrix(FibMatrix a, long p)
        {
            if (p == 1)
            {
                return a;
            }

            if (p % 2 == 1)
            {
                return new FibMatrix(PowModeFibMatrix(a, p - 1), a);
            }

            a = PowModeFibMatrix(a, p / 2);
            return new FibMatrix(a, a);
        }
    }

    public class FibMatrix
    {
        private const long MODULE = 1000000007;
        public FibMatrix()
        {
            this.Matrix = new long[2, 2];
            this.Matrix[0, 0] = 1;
            this.Matrix[0, 1] = 1;
            this.Matrix[1, 0] = 1;
            this.Matrix[1, 1] = 0;
        }

        public FibMatrix(FibMatrix A, FibMatrix B)
        {
            this.Matrix = new long[2, 2];

            this.Matrix[0, 0] = A.Matrix[0, 0] * B.Matrix[0, 0] + A.Matrix[0, 1] * B.Matrix[1, 0];
            this.Matrix[0, 1] = A.Matrix[0, 0] * B.Matrix[0, 1] + A.Matrix[0, 1] * B.Matrix[1, 1];
            this.Matrix[1, 0] = A.Matrix[1, 0] * B.Matrix[0, 0] + A.Matrix[1, 1] * B.Matrix[1, 0];
            this.Matrix[1, 1] = A.Matrix[1, 0] * B.Matrix[0, 1] + A.Matrix[1, 1] * B.Matrix[1, 1];

            this.Matrix[0, 0] %= MODULE;
            this.Matrix[0, 1] %= MODULE;
            this.Matrix[1, 0] %= MODULE;
            this.Matrix[1, 1] %= MODULE;
        }

        public long[,] Matrix { get; set; }
    }
}
