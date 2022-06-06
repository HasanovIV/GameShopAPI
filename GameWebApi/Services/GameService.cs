using GameWebApi.Database;
using GameWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameWebApi.Services
{
    public class GameService : Interfaces.IGameService
    {
        protected GameContext Context { get; set; }

        public GameService(GameContext gameContext)
        {
            Context = gameContext;
        }

        public IEnumerable<Game> GamesByCategory(int categoryId)
        {
            var _categoryGames = Context.GameCategories.Where(gg => gg.CategoryId == categoryId);
            var _games = Context.Games.Join(
                _categoryGames, g => g.Id, category => category.GameId,
                (g, category) => g);

            return _games;
        }
    }
}
