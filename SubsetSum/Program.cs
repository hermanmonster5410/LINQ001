using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SubsetSum
{
    class Program
    {
        static int[] m = new int[] { 1, 5, 7, 10, 20, 12, 16, 4, 8, 31, 40, 32, 7, 2, 9, 38, 33, 17 };

        static void Main(string[] args)
        {
            Stopwatch stpWt = new Stopwatch();

            stpWt.Start();
            Console.WriteLine("Naive: " + IsSubsetSum(m, 51));
            stpWt.Stop();
            Console.WriteLine($"Elapsed:  + {stpWt.ElapsedMilliseconds,16:N6}   {stpWt.Elapsed}" );

            stpWt.Start();
            Console.WriteLine("Dynam: " + IsSubsetSumDyn(m, m.Length, 90));
            stpWt.Stop();
            Console.WriteLine($"Elapsed:  + {stpWt.ElapsedMilliseconds,16:N6}   {stpWt.Elapsed}");


            Console.WriteLine("Done");
        }


        public static bool IsSubsetSum(int[] ar, int s)
        {
            int[] ar0 = ar.Where(a => a != s).ToArray();
            if (ar0.Length != ar.Length)                   // <== breakpoint
                return true;

            if (ar.Length < 2)
                return false;

            if ( (ar0.Length == 2) && (ar0[0] + ar0[1] == s) )
                return true;

            for ( int i = 0; i < ar0.Length; i++ )
            {
                int[] w = new int[ar0.Length - 1];
                int cur = 0;
                int s0 = 0;
                for ( int j = 0; j < ar0.Length; j++)
                {
                    if (j == i)
                        s0 = s - ar0[j];
                    else
                    {
                        w[cur++] = ar0[j];
                    }
                }

                if (IsSubsetSum(w, s0) == true)     // <== breakpoint
                    return true;
            }

            return false;
        }


        public static bool IsSubsetSumDyn(int[] set, int n, int sum)
        {
 // The value of subset[i][j] will be true if there is a subset of set[0..j-1] with sum equal to i 

            bool[,] subset = new bool[sum + 1, n + 1];

// If sum is 0, then answer is true 
            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

// If sum is not 0 and set is empty, then answer is false 
            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

// Fill the subset table in bottom up manner 
            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] ||
                                       subset[i - set[j - 1], j - 1];
                }
            }

            return subset[sum, n];
        }
    }
}
