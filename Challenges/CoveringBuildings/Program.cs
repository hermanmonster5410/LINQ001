using System;
using System.Collections.Generic;
using System.Linq;


namespace CoveringBuildings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            long[] b = {21, 1, 30, 2, 45, 3, 4, 7, 9, 4, 7, 8, 33, 10};
            List<long> lilo = b.OrderBy(x => x).ToList();

            long[] result;

            result = OptimalCover(b);
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            result = OptimalCover(new long[] { 3, 1, 4 });
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            result = OptimalCover(new long[] { 5, 3, 2, 4 });
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            result = OptimalCover(new long[] { 5, 3, 5, 2, 1 });
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            result = OptimalCover(new long[] { 7, 7, 3, 7, 7 });
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            result = OptimalCover(new long[] { 1, 1, 7, 6, 6, 6 });
            Console.WriteLine("Min sqr=" + result[0] + "   Split after=" + result[1]);

            Console.ReadKey();

        }


        public static long[] OptimalCover(long[] bldg)
        {
            long sqr = 0;
            int splitter = 0;

            long temp;
          
            long leftMax = bldg[0];
            long rightMax = FindMax(bldg, 1);

            sqr = leftMax + rightMax * (bldg.Length - 1);

            for (int i=1; i<bldg.Length-1; i++ )
            {
                if (bldg[i] > leftMax)
                    leftMax = bldg[i];

                if (bldg[i] == rightMax)
                    rightMax = FindMax(bldg, i + 1);

                if ((temp = leftMax * (i + 1) + rightMax * (bldg.Length - i - 1)) < sqr)
                {
                    sqr = temp;
                    splitter = i;
                }
            }

            return new long[] { sqr, (long)splitter };
        }

        public static long FindMax(long[] b, int i1)
        {
            long max = b[i1];
            for (int i = i1 + 1; i < b.Length; i++)
                if (b[i] > max)
                    max = b[i];
            return max;
        }
    }
}
