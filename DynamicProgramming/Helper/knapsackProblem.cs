using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class knapsackProblem
    {
        private int[] weight;
        private int[] profit;
        private int capacity;
        private int itemCount;
        private int[,] data;

        internal void GetMaxProfit()
        {
            ItemDetails();

            data = new int[itemCount, capacity + 1];

            for (int i = 1; i < itemCount; i++)
            {
                for (int j = 1; j < capacity + 1; j++)
                {
                    int q = j - weight[i] >= 0 ? data[i - 1, j - weight[i]] + profit[i] : 0;

                    if (data[i - 1, j] > q)
                    {
                        data[i, j] = data[i - 1, j];
                    }
                    else
                    {
                        data[i, j] = q;
                    }
                }
            }

            Console.WriteLine($"\nMax profit can be made : {data[itemCount-1, capacity]}");
            IncludedItems();
        }

        internal int RGetMaxProfit(int n, int w, int p)
        {
            if(n == 0 || w == 0)
            {
                return p;
            }
            else if(n < 0 || w < 0)
            {
                return 0;
            }

            int x = RGetMaxProfit(n - 1, w - weight[n], p + profit[n]);
            int y = RGetMaxProfit(n - 1, w, p);

            return x > y ? x : y;
        }

        private void ItemDetails()
        {
            Console.Write("\nEnter the count of items to be inserted : ");
            itemCount = Convert.ToInt32(Console.ReadLine()) + 1;
            Console.WriteLine();

            weight = new int[itemCount];
            profit = new int[itemCount];

            for (int i = 1; i < itemCount; i++)
            {
                Console.Write($"Enter weight of item {i} : ");
                weight[i] = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter the profit on the item {i} : ");
                profit[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
            }

            Console.Write("\nEnter the capacity of the knapsack : ");
            capacity = Convert.ToInt32(Console.ReadLine());
        }

        private void IncludedItems()
        {
            int i = itemCount - 1;
            int j = capacity;

            while(i > 0)
            {
                if(data[i, j] == data[i - 1, j])
                {
                    Console.WriteLine($"Item {i} : Not included");
                    i--;
                }
                else
                {
                    Console.WriteLine($"Item {i} : Included");
                    j = j - weight[i];
                    i--;
                }
            }
        }
    }
}
