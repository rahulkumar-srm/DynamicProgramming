using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class MultiStageGraph
    {
        static int size = 9;

        int[] cost = new int[size];
        int[] dist = new int[size];   

        int[,] weights = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 2, 1, 3, 0, 0, 0, 0, 0 }, 
            { 0, 0, 0, 0, 0, 6, 3, 0, 0 },
            { 0, 0, 0, 0, 0, 6, 7, 0, 0 }, 
            { 0, 0, 0, 0, 0, 6, 8, 9, 0 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 6 }, 
            { 0, 0, 0, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 5 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public void MultiStageShortPath()
        {
            int i = 0;

            for (i = size - 1; i > 0; i--)
            {
                int min = int.MaxValue;
                
                for(int j = i + 1; j <= size - 1; j++)
                {
                    if(weights[i, j] != 0 && (weights[i, j] + cost[j]) < min)
                    {
                        min = weights[i, j] + cost[j];
                        dist[i] = j;
                    }
                }

                cost[i] = min;
            }

            dist[i] = 1;
            dist[size - 1] = size - 1;

            Console.WriteLine("\nShotest path from source to destination");

            while (i < size - 1)
            {
                Console.Write(dist[i] + "\t");
                i = dist[i];
            }

            Console.WriteLine();
        }
    }
}
