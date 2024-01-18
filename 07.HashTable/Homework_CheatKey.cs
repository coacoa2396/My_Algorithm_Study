
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _07.HashTable
{
    public class Homework_CheatKey
    {
        private Dictionary<string, Action> cheatDic;
        
        public Homework_CheatKey()
        {
            cheatDic = new Dictionary<string, Action>();
            cheatDic.Add("Show Me The Money", ShowMeTheMoney);
            cheatDic.Add("ThereIsNoCowLevel", ThereIsNoCowLevel);
        }
        public void Run(string cheatKey)
        {
            // 조건문 없이 바로 탐색하여 치트키 발동
            cheatDic.TryGetValue(cheatKey, out Action valueFunc);
            valueFunc?.Invoke();
        }

        public void ShowMeTheMoney() 
        {
            Console.WriteLine("골드를 늘려주는 치트키 발동!");
        }

        public void ThereIsNoCowLevel()
        {
            Console.WriteLine("바로 승리합니다 치트키 발동!");
        }
    }

    public class Program1
    {
        static void Main4444(string[] args)
        {
            Homework_CheatKey homework_CheatKey = new Homework_CheatKey();
            homework_CheatKey.Run("?");
        }
    }
}
