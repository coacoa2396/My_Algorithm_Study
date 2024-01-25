using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PathFinding
{
    public class Tilemap
    {
        /****************************************************************
         * 타일맵 (Tilemap)
         * 
         * 2차원 평면의 그래프를 정점이 아닌 위치를 통해 표현하는 그래프
         * 위치의 이동가능 유무만을 표현하는 bool 이차원 타일맵
         * 타일의 종류를 표현한 이차원 타일맵이 있음
         * 인접한 이동가능한 위치간 간선이 있으며 가중치는 동일함
         ****************************************************************/

        // <타일맵 그래프>
        // false 는 이동이 불가능한 지역
        // true 는 이동이 가능한 지역
        // 한칸의 거리를 10으로 한다하면 대각선 칸은 14로 잡는다

        // 예시 - 위치의 이동가능 표현한 이차원 타일맵
        bool[,] tileMap1 = new bool[7, 7]
        {
            { false, false, false, false, false, false, false },
            { false,  true, false,  true, false, false, false },
            { false,  true, false,  true, false,  true, false },
            { false,  true, false,  true,  true,  true, false },
            { false,  true, false,  true, false, false, false },
            { false,  true,  true,  true,  true,  true, false },
            { false, false, false, false, false, false, false },
        };

        // 예시 - 타일의 종류를 표현한 이차원 타일맵
        enum TileType
        {
            None = ' ',
            Wall = '#',
            Door = '*',
            Shop = 'S',
            Gate = 'G',
        }

        char[,] tileMap2 = new char[9, 9]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', ' ', '#', '#', ' ', ' ', '#', '#', '#' },
            { '#', ' ', '#', '#', ' ', '#', '#', ' ', '#' },
            { '#', ' ', '#', '#', '*', '#', '#', '*', '#' },
            { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', 'S', ' ', ' ', ' ', 'G', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        };
    }
}
