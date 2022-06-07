using System;
using System.Collections.Generic;
using System.Linq;
using GameWebApi.Database;
using GameWebApi.Models;
using GameWebApi.Repositories.Interfaces;

namespace GameWebApi.Repositories
{
    public class GameRepository: BaseRepository<Game, Category>
    {
        public GameRepository(GameContext gameContext): base(gameContext)
        {
        }

        /// <summary>
        /// Метод возвращает объект описания найденной игры.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>{Game, Categories}</returns>
        public override (Game, IEnumerable<Category>) Get(int id)
        {
            var findGame = Context.Games.SingleOrDefault(res => res.Id == id);
            var findCategoryGame = Context.GameCategories.Where(gg => gg.GameId == findGame.Id);

            var findCategories = Context.Categories.Join(
                findCategoryGame,
                genre => genre.Id,
                fgg => fgg.CategoryId,
                (category, findGenreGame) => category);

            findGame.GameStudio = Context.Studios.SingleOrDefault(st => st.Id == findGame.GameStudioId);

            return (findGame, findCategories);
        }
    }
}
