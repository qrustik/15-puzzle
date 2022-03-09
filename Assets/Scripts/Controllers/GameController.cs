using System;
using System.Collections.Generic;
using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    abstract public class GameController
    {
        public static void OnStart(int width, int height, int id, string name)
        {
            Game.Player = new Player(id, name);
            Game.Player.Name = name;
            Game.Player.Id = id;
            Game.Grid = new Grid(width, height);
        }

        public static int GetIndexOfEmptyCell()
        {
            return Game.Grid.EmptyIndex;
        }

        public static void SwapCells(int first, int second)
        {
            var x = first % Game.Grid.Width;
            var y = first / Game.Grid.Height;
            var cellFirst = Game.Grid.GetCell(x, y);
            x = second % Game.Grid.Width;
            y = second / Game.Grid.Height;
            var cellSecond = Game.Grid.GetCell(x, y);
            Game.Grid.SwapCell(cellFirst, cellSecond);
            Game.Grid.EmptyIndex = second;
            Game.Grid.EmptyIndexI = y;
            Game.Grid.EmptyIndexJ = x;
        }

    }
}
