using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSum
{
    class Program
    {
        static int[] m = new int[] { 1, 3, 5, 10, 20, 8, 14 };

        static void Main(string[] args)
        {
            Console.WriteLine("Result: " + IsSubsetSum(m, 28));
            Console.WriteLine("Done");
        }


        public static bool IsSubsetSum(int[] ar, int s)
        {
            int[] ar0 = ar.Where(a => a != s).ToArray();
            if (ar0.Length != ar.Length)
                return true;

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

                if (IsSubsetSum(w, s0) == true)
                    return true;
            }

            return false;
        }

        public static bool IsSubsetSumX(int[] ar, int s)
        {

            return false;
        }
    }
}
