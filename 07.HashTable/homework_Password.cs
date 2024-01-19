using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _07.HashTable
{
    public class homework_Password
    {
        public static void Main123213(string[] args)
        {
            string e = Console.ReadLine();
            string[] ee = e.Split(" ");

            int N = int.Parse(ee[0]);
            int M = int.Parse(ee[1]);
            Dictionary<string, string> hp = new Dictionary<string, string>();

            do
            {
                string s = Console.ReadLine();
                string[] ss = s.Split(" ");
                N--;
                hp.Add(ss[0], ss[1]);
            } while (N > 0);

            do
            {
                string s = Console.ReadLine();
                M--;
                hp.TryGetValue(s, out string pw);
                Console.WriteLine(pw);
            } while (M > 0);
        }
    }
}
