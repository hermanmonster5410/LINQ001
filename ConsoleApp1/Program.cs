using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSumDyn
{
// A Dynamic Programming solution for subset sum problem 

//  https://www.geeksforgeeks.org/subset-sum-problem-dp-25/

    class GFG
    {
        //     Returns true if there is a subset of set[] with sum equal to given sum 

        static bool isSubsetSum(int[] set, int n, int sum)
        {
            // The value of subset[i][j] will be true if there  
            // is a subset of set[0..j-1] with sum equal to i 

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

        // Driver program  
        public static void Main()
        {
            int[] set = { 3, 34, 4, 12, 5, 2 };
            int sum = 90;
            int n = set.Length;

            bool retVal = isSubsetSum(set, n, sum);

            if ( retVal)
                Console.WriteLine("Found a subset with given sum");
            else
                Console.WriteLine("No subset with given sum");
        }
    }
}