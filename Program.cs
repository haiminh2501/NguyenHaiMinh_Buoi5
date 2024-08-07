using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanBalo
{
   
    public class Knapsack
    {
        public static int[] KnapsackProblem(int[] size, int[] val, int M, int N)
        {
            int[] cost = new int[M + 1];
            int[] best = new int[M + 1]; // Lưu trữ chỉ số của vật phẩm được chọn cho mỗi dung lượng

            // Khởi tạo mảng cost
            for (int i = 0; i <= M; i++)
            {
                cost[i] = 0;
            }

            // Điền vào bảng cost
            for (int j = 1; j <= N; j++)
            {
                for (int i = 1; i <= M; i++)
                {
                    if (i - size[j - 1] >= 0)
                    {
                        if (cost[i] < cost[i - size[j - 1]] + val[j - 1])
                        {
                            cost[i] = cost[i - size[j - 1]] + val[j - 1];
                            best[i] = j; // Lưu trữ chỉ số của vật phẩm được chọn cho dung lượng i
                        }
                    }
                }
            }

            return best; // Trả về mảng chỉ ra các vật phẩm được chọn cho mỗi dung lượng
        }

        public static void Main()
        {
            // Ví dụ sử dụng:
            int[] size = { 2, 3, 4 };
            int[] val = { 3, 4, 5 };
            int M = 5; // Dung lượng của cái ba lô
            int N = size.Length;

            int[] bestItems = KnapsackProblem(size, val, M, N);

            // Tính giá trị tối đa
            int maxValue = 0;
            int numItems = 0;
            for (int i = 1; i <= M; i++)
            {
                if (bestItems[i] > 0)
                {
                    maxValue += val[bestItems[i] - 1];
                    numItems++;
                }
            }

            Console.WriteLine("Gia tri toi đa: "+maxValue);
            Console.WriteLine("So luong mon đo: "+numItems);

          
            Console.ReadLine();
        }
    }
}
