using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
    public class Homework_N_M
    {
        public static StringBuilder sb = new StringBuilder();


        public static void JoinSequence(HashSet<string> hs, int[] Nums, Stack<int> stack, int N, int M)
        {
            if (stack.Count == M)
            {
                string joinedNums = string.Join(" ", stack.Reverse());
                hs.Add(joinedNums);
                sb.AppendLine(joinedNums);
                return;
            }
            for (int i = 0; i < N; i++)
            {
                stack.Push(Nums[i]);
                JoinSequence(hs, Nums, stack, N, M); // 재귀 호출
                stack.Pop();    // 백트래킹
            }
        }


        public static void Main123214(string[] args)
        {
            HashSet<string> answer = new HashSet<string>();
            string s = Console.ReadLine();
            string[] ss = s.Split(" ");
            int N = int.Parse(ss[0]);
            int M = int.Parse(ss[1]);

            int[] Nums = new int[N];                // 수열을 만들 숫자들의 배열을 만든다
            for (int i = 1; i <= N; i++)
            {
                Nums[i - 1] = i;
            }

            Stack<int> pick = new Stack<int>();
            JoinSequence(answer, Nums, pick, N, M);
            Console.WriteLine(sb.ToString());
        }
    }
}
