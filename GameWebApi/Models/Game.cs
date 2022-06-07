using System;
using System.Collections.Generic;

namespace GameWebApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int GameStudioId { get; set; }
        public Studio GameStudio{ get; set; }

        public IEnumerable<GameCategory> GameCategories { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
