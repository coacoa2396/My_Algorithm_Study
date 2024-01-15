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
                        if (stack.Peek() != '[')
                        {
                            judgement = false;
                        }
                        else
                        {
                            stack.Pop();
                        }
                        break;
                    case '}':
                        if (stack.Peek() != '{')
                        {
                            judgement = false;
                        }
                        else
                        {
                            stack.Pop();
                        }
                        break;
                    case ')':
                        if (stack.Peek() != '(')
                        {
                            judgement = false;
                        }
                        else
                        {
                            stack.Pop();
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
        static void Main21532152137317613245r(string[] args)
        {
            Homework1 homework1 = new Homework1();
            bool a = homework1.IsOk("[{(]})");
            Console.WriteLine(a);
        }
    }




    public class Homework2
    {
        // <작업 프로세스>
        // 각 작업이 몇시간이 걸리는 작업인지 포함한 배열이 있으며
        // 하루에 8시간씩 일할 수 잇는 회사가 있음.
        // 남는시간없이 주어진 일을 계속 한다고 했을 때
        // 각각의 작업이 끝나는 날짜를 결과 배열로 출력하는 함수 작성

        public int[] ProcessJob(int[] jobList)
        {
            Queue<int> answer = new Queue<int>();
            int spareTime = 8;
            int spareJob = 0;
            int day = 1;
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < jobList.Length; i++)
            {
                queue.Enqueue(jobList[i]);
            }

            spareJob = queue.Dequeue();
            do
            {          
                if (spareJob - spareTime <= 0)
                {
                    answer.Enqueue(day);
                    spareTime = Math.Abs(spareJob - spareTime);
                    if (queue.Count == 0)
                        break;
                    if(queue.Count > 0)
                        spareJob = queue.Dequeue();
                    if (spareTime == 0)
                    {
                        day++;
                        spareTime = 8;
                    }
                }
                else if (spareJob - spareTime > 0)
                {
                    spareJob = spareJob - spareTime;
                    spareTime = 8;
                    day++;
                }            
            } while (queue.Count >= 0 && spareJob > 0);
            
            int[] answerArray = answer.ToArray();
            
            for (int i = 0; i < answerArray.Length; i++)
            {
                Console.WriteLine(answerArray[i]);
            }
            return answerArray;
        }

        static void Main1111(string[] args)
        {
            Homework2 homework2 = new Homework2();
            int[] jobList = { 4, 4, 12, 10, 2, 10 };
            homework2.ProcessJob(jobList);
        }



    }
}
