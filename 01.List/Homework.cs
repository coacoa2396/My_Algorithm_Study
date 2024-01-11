using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _01.List
{
    
    public class Homework1      // 1~4번 문제
    {
        public static void MakeList(int input)
        {
            List<int> list = new List<int>(input);
            
            for (int i = 0; i < input +1; i++)
            {
                list.Add(i);
            }
        }

        static void Main1(string[] args)
        {
            int input;
            bool a;
            do
            {
                 a = int.TryParse(Console.ReadLine(), out input);
            } while (a == false);

            MakeList(input);
        }
    }

    public class Homework2      // 5번 문제
    {
        public static void CheckList(List<int> list, int input)
        {
            
            int index = list.IndexOf(input);

            if(index == -1)
            {
                list.Add(input);
            }
            else
            {
                list.Remove(input);
            }
        }

        static void Main2(string[] args) 
        {
            List<int> list = new List<int>();
            int input;
            bool a;

            do
            {
                a = int.TryParse(Console.ReadLine(), out input);
            } while (a == false);

            CheckList(list, input);
        }
    }


    public class Inventory          // 인벤토리 문제
    {
        List<string> list;
        public Inventory()
        {
            list = new List<string>();
        }
        public void InventoryOpen()
        {
            Console.WriteLine("==========인벤토리==========\n");
            if (list[0] == null)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");                
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("===인벤토리 목록===\n");
                    Console.WriteLine($"{i+1}. {list[i]}");
                }
            }                
        }

        public void Storing(string itemName)             // 인벤토리에 넣기
        {
            list.Add(itemName);
            Console.WriteLine($"{itemName}을 넣었습니다.");
        }

        public void Dropping(string itemName)            // 인벤토리에서 버리기
        {
            list.Remove(itemName);
            Console.WriteLine($"{itemName}을 버렸습니다.");
        }
               
    }

    public class Program1
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.InventoryOpen();
        }
    }
}
