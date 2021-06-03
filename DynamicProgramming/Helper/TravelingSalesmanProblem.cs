using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class TravelingSalesmanProblem
    {
        static int len = 4;
        static int limit = (1 << len) - 1;

        internal int[,] dp = new int[5, 1 << len];
        internal int[] path = new int[len];

        private int[,] cost = { 
            { 0, 0, 0, 0, 0 },
            { 0, 0, 10, 15, 20},
            { 0, 5, 0, 9, 10 },
            { 0, 6, 13, 0, 12 },
            { 0, 8, 8, 9, 0 } 
        };

        internal int MinTravelingCost(int idx, int mask)
        {
            if (mask == limit)
            {
                return cost[idx + 1, 1];
            }

            if (dp[idx, mask] > 0)
            {
                return dp[idx, mask];
            }

            int ret = int.MaxValue;

            for (int i = 0; i < len; i++)
            {
                if ((mask & (1 << i)) == 0)
                {
                    int newMask = mask | (1 << i);
                    ret = FindMinCost(ret , MinTravelingCost(i, newMask) + cost[idx + 1, i + 1]);
                }
            }

            return dp[idx, mask] = ret;
        }

        private int FindMinCost(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
