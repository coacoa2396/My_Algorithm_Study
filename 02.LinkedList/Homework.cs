
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02.LinkedList
{
    public class Homework1              // 기본 과제
    {
        public static LinkedList<int> list;

        public Homework1()
        {
            list = new LinkedList<int>();
        }
        public int userInput()
        {
            int input;
            bool a;
            do
            {
                Console.Write("숫자를 입력하세요 : ");
                do
                {
                    a = int.TryParse(Console.ReadLine(), out input);
                    Console.WriteLine();
                } while (input == 0);
            } while (a == false);
            return input;
        }
        public void Judgement(int input)
        {

            if (input < 0)
            {
                list.AddFirst(input);
            }
            else
            {
                list.AddLast(input);
            }

            Console.WriteLine("리스트를 나열합니다.");
            foreach (int element in list) { Console.Write($"{element} "); }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    public class Program1
    {
        static void Main1111111(string[] args)
        {
            Homework1 list = new Homework1();

            while (true)
            {
                int a = list.userInput();
                list.Judgement(a);
            }
        }
    }




    // 요세푸스 순열 문제
    public class Homework2
    {
        public void Josephus(int n, int k)
        {


            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> node;

            LinkedList<int> answer = new LinkedList<int>();

            for (int i = 1; i <= n; i++)
            {
                list.AddLast(i);
            }

            while (list.Count > 0)
            {
                for (int i = 1; i <= k; i++)
                {
                    node = list.First;
                    if (i == k)
                    {
                        // 빼서 답 리스트에 넣기
                        list.Remove(node);
                        answer.AddLast(node);
                    }
                    else
                    {
                        // First 자료를 Last로 옮기기
                        list.Remove(node);
                        list.AddLast(node);
                    }
                }
            }
            foreach (int element in answer) { Console.Write($"{element} "); }

        }
    }

    public class Program2
    {
        static void Main(string[] args)
        {
            Homework2 list = new Homework2();
            list.Josephus(7, 3);
        }
    }
}
