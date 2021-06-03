using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class OptimalBinarySearchTree
    {
        static int size = 5;
        int[] keys = { 0, 10, 20, 30, 40 };
        int[] p = { 0, 3, 3, 1, 1 };
        int[] q = { 2, 3, 1, 1, 1 };

        int[,] cost = new int[size, size];
        int[,] weight = new int[size, size];
        int[,] r = new int[size, size];

        internal void optimalSearchTree()
        {
            for (int n = 0; n < size; n++)
            {
                for (int i = 0; i < size - n; i++)
                {
                    int j = i + n;
                    int min = int.MaxValue;

                    weight[i, j] = Sum(i, j);

                    for (int k = i + 1; k <= j; k++)
                    {
                        int c = cost[i, k - 1] + cost[k, j] + weight[i, j];

                        if (c < min)
                        {
                            min = c;
                            cost[i, j] = min;
                            r[i, j] = k;
                        }
                    }

                }
            }

            Console.WriteLine($"\nMinimum Cost BST : {cost[0, size - 1]}");
            Console.WriteLine("Pre-order form of tree");
            PreOrder(0, size - 1);
            Console.WriteLine();
        }

        private int Sum(int startIndex, int endIndex)
        {
            if(startIndex == endIndex)
            {
                return q[endIndex];
            }

            return weight[startIndex, endIndex -1] + p[endIndex] + q[endIndex];
        }

        private void PreOrder(int start, int end)
        {
            int root = r[start, end];

            if(root != 0)
            {
                Console.Write(keys[root] + "\t");
                PreOrder(start, root - 1);
                PreOrder(root, end);
            }
        }
    }
}
