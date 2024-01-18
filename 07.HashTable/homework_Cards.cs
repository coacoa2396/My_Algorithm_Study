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
            int n = int.Parse(Console.ReadLine());
            string[] my_deck = new string[n];
            int k = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            HashSet<string> hashSet = new HashSet<string>();

            int deckCount = n;
            for (int i = 0; i < deckCount; i++)
            {
                my_deck[i] = Console.ReadLine();
            }
            // 입력 완료

            string result;
            for(int a = 0; a < my_deck.Length; a++)
            {
                result = "";
                do
                {
                    stack.Push(my_deck[a]);
                } while ();
            }

        }
    }
}
