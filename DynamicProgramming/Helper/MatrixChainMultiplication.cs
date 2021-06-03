using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class MatrixChainMultiplication
    {
        int size = 5;
        int[,] cost = new int[5, 5];
        int[,] d = new int[5, 5];

        int[] dimension = { 3, 2, 4, 2, 5 };

        internal void MatrixMultiplcationSeq()
        {
            for(int n = 1; n < size - 1; n++)
            {
                for(int i = 1; i < size - n; i++)
                {
                    int min = int.MaxValue;
                    int j = i + n;

                    for(int k = i; k < j; k++)
                    {
                        int q = cost[i, k] + cost[k + 1, j] + (dimension[i - 1] * dimension[k] * dimension[j]);

                        if (q < min)
                        {
                            min = q;
                            d[i, j] = k;
                        }
                    }

                    cost[i, j] = min;
                }
            }

            char name = 'A';
            Console.Write("\nMatrix multication sequence : ");

            PrintMulticationSeq(1, size - 1, ref name);

            Console.WriteLine($"\nMinimum multiplication cost : {cost[1, size - 1]}");

        }

        private void PrintMulticationSeq(int low, int high, ref char name)
        {
            if(low == high)
            {
                Console.Write(name);
                name++;
                return;
            }

            Console.Write("(");

            PrintMulticationSeq(low, d[low, high], ref name);
            PrintMulticationSeq(d[low, high] + 1, high, ref name);

            Console.Write(")");
        }
    }
}
