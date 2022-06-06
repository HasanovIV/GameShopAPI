using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        public Game  Game{ get; set; }
        public Genre Genre{ get; set; }

    }
}
