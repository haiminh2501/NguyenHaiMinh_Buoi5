using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java
{

    public class KnapsackProblem
    {
        public static int Solve(int[] w, int[] v, int S)
        {
            int n = w.Length;
            int[,] dp = new int[n + 1, S + 1];

            // Khởi tạo
            for (int j = 0; j <= S; j++)
                dp[0, j] = 0;

            // Điền bảng dp
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= S; j++)
                {
                    if (w[i - 1] <= j)
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - w[i - 1]] + v[i - 1]);
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            // In ra bảng dp
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= S; j++)
                    Console.Write(dp[i, j] + " ");
                Console.WriteLine();
            }

            return dp[n, S];
        }

        static void Main(string[] args)
        {
            int[] w = { 2, 3, 4, 5 };
            int[] v = { 3, 4, 5, 6 };
            int S = 8;
            int maxValue = Solve(w, v, S);
            Console.WriteLine("Maximum value: " + maxValue);
            Console.ReadLine();
        }
    }
}
