using System;
using System.Collections;
using System.Collections.Generic;

namespace GameWebApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Studio GameStudio{ get; set; }

        public IEnumerable<GameGenre> GameGenres { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(int id)
        {
            return Id == id;
        }
    }
}
