using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Grid
    {
        private int _width;
        private int _height;
        private Cell[,] _cells;
        private int _emptyIndexI, _emptyIndexJ;
        private int _emptyIndex;


        public Grid(int width, int height)
        {
            _width = width;
            _height = height;

            _cells = new Cell[height, width];

            int count = 0;

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    _cells[i, j] = new Cell(count++);
                }
            }

            _emptyIndexI = height - 1;
            _emptyIndexJ = width - 1;
            _emptyIndex = count - 1;
        }



        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int EmptyIndexI { get => _emptyIndexI; set => _emptyIndexI = value; }
        public int EmptyIndexJ { get => _emptyIndexJ; set => _emptyIndexJ = value; }
        public int EmptyIndex { get => _emptyIndex; set => _emptyIndex = value; }

        public Cell GetEmptyCell()
        {
            return _cells[_emptyIndexI, _emptyIndexJ];
        }

        public Cell GetCell(int x, int y)
        {
            return _cells[y,x];
        }

        public void SwapCell(Cell first, Cell second)
        {
            var tmp = first.Value;
            first.Value = second.Value;
            second.Value = tmp;

        }

        public void Mixing()
        {

        }


    }
}


