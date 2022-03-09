using System;
using System.Collections.Generic;


namespace Assets.Scripts.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Player(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
