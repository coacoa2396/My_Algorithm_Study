using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PathFinding
{
    public class AStar
    {
        /************************************************************
         * A* 알고리즘
         * 
         * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
         * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
         ************************************************************/
        //다익스트라 : 방문하지 않은 정점 중 가장 가까운 정점 선택
        //     A*   : 방문하지 않은 정점 중 예상 가중치가 가장 가까운 정점 선택

        // A*와는 다르게 다익스트라의 경우는 전방향으로 탐색을 하기때문에
        // 불필요한 방향으로 과다하게 탐색을 하기 때문에 나온 알고리즘이다
        // A*는 좌표가 있기 때문에 우선적으로 탐색을 해야하는 방향을 지정할 수 있다

        // 가중치가 가까운 정점 : 베스트 상황일 때 예상되는 소요 거리가 가장 낮은 인접 정점

        // 가중치 계산 방법 : f, g, h 의 점수를 가지고 판단
        // f : 총점 (g+h)
        // g : 실제 이동 거리
        // h : 예상 남은 거리 (휴리스틱 - Heuristics) - 맨해튼거리 or 유클리드거리 방법을 사용한다
        // 진행방향이 막혀있는 경우 다음 최소점수를 탐색한다
        // 총점(f)가 동일한 경우 g가 높은 것을 우선으로 탐색, h(남은거리)가 낮은 것을 우선으로 탐색하기 때문

        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static Point[] Direction =
        {
            new Point(  0, +1 ),            // 상
            new Point(  0, -1 ),            // 하
            new Point( -1,  0 ),            // 좌
            new Point( +1,  0 ),            // 우
            new Point( -1, +1 ),            // 좌상
            new Point( -1, -1 ),            // 좌하
            new Point( +1, +1 ),            // 우상
            new Point( +1, -1 )             // 우하
        };

        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);       // 행의 개수
            int xSize = tileMap.GetLength(1);       // 열의 개수

            ASNode[,] nodes = new ASNode[ySize, xSize];             // 순서는 [y, x]
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> pq = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, new Point(), 0, Heuristic(start, end));
            nodes[startNode.pos.y, startNode.pos.x] = startNode;
            pq.Enqueue(startNode, startNode.f);

            while (pq.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = pq.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.pos.y, nextNode.pos.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.pos.x == end.x && nextNode.pos.y == end.y)
                {
                    path = new List<Point>();

                    Point point = end;
                    while ((point.x == start.x && point.y == start.y) == false)
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);

                    path.Reverse();
                    return true;
                }

                // 4. AStar 탐색을 진행 : 탐색한 정점 주변의 점수 계산
                // 방향 탐색
                for (int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.pos.x + Direction[i].x;
                    int y = nextNode.pos.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우를 제외하자
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;
                    // 대각선으로 이동이 불가능 지역인 경우
                    else if (i >= 4 && tileMap[y, nextNode.pos.x] == false && tileMap[nextNode.pos.y, x] == false)
                        continue;

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.pos.x == x || nextNode.pos.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        pq.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 직선을 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            // return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);

            // 타일맵 유클리드 거리 : 직선과 대각선을 통해 이동하는 거리
            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;
            return CostStraight * straightCount + CostDiagonal * diagonalCount;

            // 다익스트라
            // return 0;
        }

        private class ASNode
        {
            public Point pos;     // 현재 정점
            public Point parent;    // 이 정점을 탐색한 정점의 위치

            public int f;           // 총 예상 거리 : f = g + h
            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 휴리스틱, 앞으로 예상되는 값, 목표까지 추정 경로 가중치, 장애물 고려 X

            public ASNode(Point pos, Point parent, int g, int h)
            {
                this.pos = pos;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

