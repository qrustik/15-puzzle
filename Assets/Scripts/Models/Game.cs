using System;
using System.Collections.Generic;
using Assets.Scripts.Views;

namespace Assets.Scripts.Models
{
    abstract public class Game
    {
        private static Player _player;
        private static Grid _grid;

        public static Player Player { get => _player; set => _player = value; }
        public static Grid Grid { get => _grid; set => _grid = value; }
    }
}
