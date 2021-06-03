using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Helper
{
    internal class LCSProblem
    {
        internal void LCS(char[] mainString, char[] secString)
        {
            int fSize = mainString.Length + 1;
            int sSize = secString.Length + 1;

            int[,] data = new int[fSize, sSize];

            for(int i = 1; i < fSize; i++)
            {
                for(int j = 1; j < sSize; j++)
                {
                    if(mainString[i - 1] == secString[j - 1])
                    {
                        data[i, j] = data[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        data[i, j] = Max(data[i, j - 1], data[i -1 , j]);
                    }
                }
            }

            DisplayLCS(mainString, secString, data);
        }

        internal int RLCS(char[] mainString, char[] secString, int pfString, int psString)
        {
            if (pfString > mainString.Length - 1 || psString > secString.Length - 1)
                return 0;

            if(secString[psString] == mainString[pfString])
            {
                return 1 + RLCS(mainString, secString, pfString + 1, psString + 1);
            }
            else
            {
                return Max(RLCS(mainString, secString, pfString + 1, psString), RLCS(mainString, secString, pfString, psString + 1));
            }
        }

        private static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        private void DisplayLCS(char[] mainString, char[] secString, int[,] data)
        {
            int i = mainString.Length;
            int j = secString.Length;

            string result = string.Empty;

            Console.WriteLine($"\nLength of Longest common subsequnce : {data[i ,j]}");
            Console.Write($"Longest common subsequnce : ");

            while(data[i, j] > 0)
            {
                if(data[i, j] != data[i, j -1])
                {
                    result += secString[j-1];
                    i--;
                    j--;
                }
                else
                {
                    j--;
                }
            }

            Console.WriteLine(new string(result.Reverse().ToArray()));
            Console.WriteLine();
        }
    }
}
