using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _07.HashTable
{
    public class homework_Cards
    {
        public static void Main1213(string[] args)
        {
            HashSet<string> hashSet = new HashSet<string>();
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            string[] my_deck = new string[n];

            
            for (int i = 0; i < n; i++)
            {
                my_deck[i] = Console.ReadLine();
            }
            // 입력 완료



        }
    }
}
