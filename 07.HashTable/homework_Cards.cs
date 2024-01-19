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
        public static void Main(string[] args)
        {
            HashSet<int> hashSet = new HashSet<int>();// 중복방지 HashSet

            int n = int.Parse(Console.ReadLine());          // 카드 개수
            int k = int.Parse(Console.ReadLine());          // 선택할 카드 개수
            string[] my_deck = new string[n];               // 카드 값을 저장할 배열


            for (int i = 0; i < n; i++)
            {
                my_deck[i] = Console.ReadLine();            // 카드 값들을 입력 받기
            }
            // 입력 완료

            int[] cards = new int[n];                       // 문자열로 입력 받은 값을 정수형으로 받을 배열 생성
            for (int i = 0; i < n; i++)
            {
                cards[i] = int.Parse(my_deck[i]);           // 변형해서 대입
            }

            // 고른 카드를 저장할 리스트를 만든다
            List<int> pickedCards;

            // 첫번째 카드를 뽑은 카드 리스트에 넣는다
            for (int i = 0; i < n; i++)
            {
                pickedCards = new List<int> { cards[i] };   // 첫번째 카드를 리스트에 넣는다


                for (int j = i + 1; j < n; j++)            // 나머지 카드를 하나씩 리스트에 넣는다 << k번만큼 반복한다
                {
                    
                    pickedCards.Add(cards[j]);

                    if (pickedCards.Count == k)             // 넣은 카드의 수가 k와 동일해지면
                    {
                        // 리스트 안의 숫자를 병합하고 저장한다
                        int joinedNum = int.Parse(string.Join("", pickedCards));
                        // 저장한 숫자를 hashSet에 저장한다
                        hashSet.Add(joinedNum);
                        // 제일 마지막에 넣은 것을 하나 삭제해서 다음 것을 넣게 해준다
                        pickedCards.RemoveAt(pickedCards.Count - 1);
                    }
                }
            }
            // hasgSet에 넣은 숫자의 개수를 출력한다
            Console.WriteLine(hashSet.Count);
        }
    }
}
