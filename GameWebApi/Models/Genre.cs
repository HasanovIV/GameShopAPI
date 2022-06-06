using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<GameGenre> GameGenres { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
