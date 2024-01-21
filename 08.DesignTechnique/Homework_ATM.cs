using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.DesignTechnique
{
    public class Homework_ATM
    {

        public static void Main(string[] args)
        {
            string N = Console.ReadLine();
            string s = Console.ReadLine();
            string[] ss = s.Split(" ");

            int[] usingTime = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
                usingTime[i] = int.Parse(ss[i]);

            Array.Sort(usingTime);
            int[] timeSum = new int[usingTime.Length];
            for (int i = 0; i < usingTime.Length; i++)
            {
                if (i == 0)
                {
                    timeSum[i] = usingTime[i];
                }
                else
                {
                    timeSum[i] = timeSum[i - 1] + usingTime[i];
                }
            }

            Console.WriteLine(timeSum.Sum());
        }
    }
}
