using System;
namespace GameWebApi.Models
{
    public class GameCategory
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game  Game{ get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
