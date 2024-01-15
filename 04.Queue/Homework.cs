using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Queue
{
    internal class Homework1
    {
        // <괄호 검사기를 구현하자>
        // 텍스트를 입력으로 받아서 괄호가 유효한지 판단하는 함수
        // bool IsOk(string text){}
        // 검사할 괄호 : [], {}, ()

        public Homework1()
        {

        }
        
        public bool IsOk(string text)
        {
            bool judgement = true;
            char a;
            Stack<char> stack = new Stack<char>();

            for(int i = 0; i < text.Length; i++)
            {
                switch (text[i]) 
                { 
                    case '[':
                    case '{':
                    case '(':
                        stack.Push(text[i]);
                        break;
                    case ']':
                    case '}':
                    case ')':
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            judgement = false;
                        }
                        break;
                }           
            }

            if (stack.Count > 0)
            {
                judgement = false;
            }
           
            return judgement;
        }
        static void Main315462446421843123512145420154512(string[] args)
        {
            Homework1 homework1 = new Homework1();
            bool a = homework1.IsOk("[{{}]");
            Console.WriteLine(a);
        }
    }
}
