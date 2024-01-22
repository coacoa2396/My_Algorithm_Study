namespace _09.Sort
{
    internal class Program
    {
        static void Main1031(string[] args)
        {
            Random random = new Random();
            int count = 20;

            List<int> selectionList = new List<int>(count);
            List<int> insertionList = new List<int>(count);
            List<int> bubbleList = new List<int>(count);
            List<int> mergeList = new List<int>(count);
            List<int> quickList = new List<int>(count);
            List<int> introList = new List<int>(count);

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(1, 101);
                Console.Write($"{rand,3}");

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                introList.Add(rand);
            }
            Console.WriteLine();

            Console.WriteLine("선택정렬 결과 : ");
            Sorting.SelectionSort(selectionList, 0, selectionList.Count - 1);
            foreach(int value in selectionList)
            {
                Console.Write($"{value, 3}");
            }
            Console.WriteLine();

            Console.WriteLine("삽입 정렬 결과 :");
            Sorting.InsertionSort(insertionList, 0, insertionList.Count - 1);
            foreach (int value in insertionList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("버블 정렬 결과 :");
            Sorting.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
            foreach (int value in bubbleList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("병합 정렬 결과 :");
            Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);
            foreach (int value in mergeList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            Console.WriteLine("퀵 정렬 결과 :");
            Sorting.QuickSort(quickList, 0, quickList.Count - 1);
            foreach (int value in quickList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();


            // 인트로 정렬은 퀵 + 힙 + 삽입 을 섞어서 진행함
            // 퀵부터 시도하고 퀵의 시간복잡도가 길어지면 힙으로 갔다가 마지막에 삽입정렬로 마무리
            Console.WriteLine("인트로 정렬 결과 :");
            introList.Sort();
            foreach (int value in introList)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }
    }
}
