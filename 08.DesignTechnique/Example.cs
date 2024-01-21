using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
    public class Example
    {
        // 연속합 : 백준 1912

        static void Main123125451(string[] args)
        {
            int[] values = { 10, -4, 3, 1, 5, 6, -35, 12, 21, -1 };
            int max = int.MinValue;

            // ex) [2,4] : 2 ~ 4 더한 값
            int[,] result = new int[values.Length, values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                result[i,i] = values[i];
            }

            for (int start = 0; start < values.Length - 1; start++)
            {
                for(int end = start+1; end < values.Length;end++)
                {
                    result[start, end] = result[start, end -1] + values[end];
                    if (max < result[start, end])
                    {
                        max = result[start, end];
                    }
                }
            }
        }
    }
}
