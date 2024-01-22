using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sort
{
    public class Homework
    {
        // 선택정렬
        // 작은 데이터부터 앞에 쌓아가며 정렬
        public static void SelectedSort(List<int> list, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                int smaller = i;
                for (int j = i + 1; j <= end; j++)
                {
                    if (list[smaller] >= list[j])
                        smaller = j;
                }
                Swap(list, i, smaller);
            }
        }

        // 삽입정렬
        // 뒤에서부터 비교해서 원본 데이터가 비교데이터보다 작으면 앞으로 한칸 가면서 정렬
        public static void InsertionSort(List<int> list, int start, int end)
        {
            for (int i = start + 1; i <= end; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (list[j - 1] > list[j])
                    {
                        Swap(list, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        // 버블정렬
        // 큰 데이터를 뒤로 밀어서 뒤부터 정렬
        public static void BubbleSort(List<int> list, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                for (int j = start; j < end - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        // 병합정렬
        // 데이터를 2분할하여 정렬 후 합병 
        public static void MergeSort(List<int> list, int start, int end)
        {
            // 재귀함수
            // 더 공부하자
            int mid = (start + end) / 2;
        }


        // 퀵정렬
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬

        // A++) 힙정렬

        public static void Swap(List<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }



    public class HomeworkTest
    {
        public static void Main(string[] args)
        {
            Homework homework = new Homework();
            Random rand = new Random();
            int count = 10;

            List<int> selectedList = new List<int>(count);
            List<int> insertionList = new List<int>(count);
            List<int> bubbleList = new List<int>(count);

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int random = rand.Next(1, 100);
                Console.Write($"{random,3}");

                selectedList.Add(random);
                insertionList.Add(random);
                bubbleList.Add(random);
            }
            Console.WriteLine();

            Console.WriteLine("선택 정렬 결과 : ");
            Homework.SelectedSort(selectedList, 0, selectedList.Count - 1);
            foreach (int a in selectedList)
            {
                Console.Write($"{a,3}");
            }
            Console.WriteLine();

            Console.WriteLine("삽입 정렬 결과 : ");
            Homework.InsertionSort(insertionList, 0, insertionList.Count - 1);
            foreach (int a in insertionList)
            {
                Console.Write($"{a,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 : ");
            Homework.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
            foreach (int a in bubbleList)
            {
                Console.Write($"{a,3}");
            }
            Console.WriteLine();
        }
    }
}
