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
                    Environment.NewLine + "2. All Pairs Shortest Path - FloydWarshall" + //Time Complexity(n^3)
                    Environment.NewLine + "3. Matrix Chain Multiplication" + //Time Complexity(n^3)
                    Environment.NewLine + "4. Single Source Shortest Path - Bellman Ford" + //Best Case - Time Complexity(n^2), Worst Case - Time Complexity(n^3)
                    Environment.NewLine + "5. 0/1 Knapsack Problem" + //Time Complexity(2^n)
                    Environment.NewLine + "6. Optimal Binary Search Tree" + //Time Complexity(n^3)
                    Environment.NewLine + "7. Traveling Salesman Problem" + //Time Complexity(n^2*2^n)
                    Environment.NewLine + "8. Longest Common Subsequence Problem" +
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
                    FloydWarshall pairsShortestPath = new FloydWarshall();
                    pairsShortestPath.ShortestPathPair();
                }
                else if (i == 3)
                {
                    MatrixChainMultiplication matrixChainMultiplication = new MatrixChainMultiplication();
                    matrixChainMultiplication.MatrixMultiplcationSeq();
                }
                else if (i == 4)
                {
                    BellmanFord bellmanFord = new BellmanFord();
                    bellmanFord.ShortestPathPair();
                }
                else if (i == 5)
                {
                    knapsackProblem knapsackProblem = new knapsackProblem();
                    knapsackProblem.GetMaxProfit();
                }
                else if(i == 6)
                {
                    OptimalBinarySearchTree optimalBinarySearchTree = new OptimalBinarySearchTree();
                    optimalBinarySearchTree.optimalSearchTree();
                }
                else if(i == 7)
                {
                    Console.Write("\nEnter the starting vertex : ");
                    int idx = Convert.ToInt32(Console.ReadLine());

                    TravelingSalesmanProblem travelingSalesmanProblem = new TravelingSalesmanProblem();
                    Console.WriteLine($"Minimmun cost : {travelingSalesmanProblem.MinTravelingCost(0, 1 << (idx - 1))}");
                }
                else if(i == 8)
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
