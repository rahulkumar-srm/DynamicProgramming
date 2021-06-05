using DynamicProgramming.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    Environment.NewLine + "1. MultiStageGraph Problem" + //Time Complexity(n^2)
                    Environment.NewLine + "2. Matrix Chain Multiplication" + //Time Complexity(n^3)
                    Environment.NewLine + "3. 0/1 Knapsack Problem" + //Time Complexity(2^n)
                    Environment.NewLine + "4. Optimal Binary Search Tree" + //Time Complexity(n^3)
                    Environment.NewLine + "5. Traveling Salesman Problem" + //Time Complexity(n^2*2^n)
                    Environment.NewLine + "6. Longest Common Subsequence Problem" +
                    Environment.NewLine + "0. Exit\n"
                );

                Console.Write("Please select an option : ");

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    MultiStageGraph multiStageGraph = new MultiStageGraph();
                    multiStageGraph.MultiStageShortPath();
                }
                else if (i == 2)
                {
                    MatrixChainMultiplication matrixChainMultiplication = new MatrixChainMultiplication();
                    matrixChainMultiplication.MatrixMultiplcationSeq();
                }
                else if (i == 3)
                {
                    knapsackProblem knapsackProblem = new knapsackProblem();
                    knapsackProblem.GetMaxProfit();
                }
                else if(i == 4)
                {
                    OptimalBinarySearchTree optimalBinarySearchTree = new OptimalBinarySearchTree();
                    optimalBinarySearchTree.optimalSearchTree();
                }
                else if(i == 5)
                {
                    Console.Write("\nEnter the starting vertex : ");
                    int idx = Convert.ToInt32(Console.ReadLine());

                    TravelingSalesmanProblem travelingSalesmanProblem = new TravelingSalesmanProblem();
                    Console.WriteLine($"Minimmun cost : {travelingSalesmanProblem.MinTravelingCost(0, 1 << (idx - 1))}");
                }
                else if(i == 6)
                {
                    Console.Write("\nEnter the first string : ");
                    string str1 = Console.ReadLine();

                    Console.Write("\nEnter the second string : ");
                    string str2 = Console.ReadLine();

                    LCSProblem lCSProblem = new LCSProblem();
                    lCSProblem.LCS(str1.ToCharArray(), str2.ToCharArray());
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
