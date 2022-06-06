using System;
using System.Collections.Generic;
using System.Linq;
using GameWebApi.Database;
using GameWebApi.Models;
using GameWebApi.Repositories.Interfaces;

namespace GameWebApi.Repositories
{
    public class GameRepository: BaseRepository<Game>
    {
        public GameRepository(GameContext gameContext): base(gameContext)
        {
        }

        public override object Get(int id)
        {
            var findGame = Context.Games.SingleOrDefault(res => res.Id == id);
            var findCategoryGame = Context.GameCategories.Where(gg => gg.GameId == findGame.Id);

            var findCategories = Context.Categories.Join(
                findCategoryGame,
                genre => genre.Id,
                fgg => fgg.CategoryId,
                (category, findGenreGame) => category);

            findGame.GameStudio = Context.Studios.SingleOrDefault(st => st.Id == findGame.GameStudioId);

            var result = new { Game = findGame, Categories = findCategories };

            return result;
        }
    }
}
