using System;
using System.Collections.Generic;


namespace Assets.Scripts.Models
{
    public class Cell
    {
        private int? _value;

        public Cell(int? value)
        {
            _value = value;
        }

        public int? Value { get => _value; set => _value = value; }
    }
}
