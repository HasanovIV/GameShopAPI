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
            var findGenreGame = Context.GameGenres.Where(gg => gg.GameId == findGame.Id);

            var findGenres = Context.Genres.Join(
                findGenreGame,
                genre => genre.Id,
                fgg => fgg.GenreId,
                (genre, findGenreGame) => genre);

            findGame.GameStudio = Context.Studios.SingleOrDefault(st => st.Id == findGame.GameStudioId);

            var result = new { Game = findGame, Genres = findGenres };

            return result;
        }
    }
}
