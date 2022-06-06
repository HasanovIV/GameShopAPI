using GameWebApi.Models;
using GameWebApi.Repositories.Interfaces;
using GameWebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {
        public GameRepository(GameContext gameContext) : base(gameContext)
        {

        }

        public override Game Get(int id)
        {
            //return Context.Games.SingleOrDefault(g => g.Id == id);
            return base.Get(id);
        }
    }
}
