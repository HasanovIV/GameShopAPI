using GameWebApi.Models;
using System;
using System.Linq;

namespace GameWebApi.Database
{
    public static class InitialDatabase
    {

        /// <summary>
        /// Метод заполняет начальные данные в базе, если в базе они отсутствуют.
        /// Упращает тестирование и начальное заполнение данных.
        /// </summary>
        public static void InitialData(GameContext gameContext)
        {
            if (!gameContext.Categories.Any())
            {
                InitialStudies(gameContext);
                InitialCategories(gameContext);
                InitialGames(gameContext);
                InitialGameCategories(gameContext);
            }
        }

        private static void InitialGames(GameContext gameContext)
        {
            gameContext.Games.Add(new Game() { Name = "Ведьмак", GameStudioId = 1 });
            gameContext.Games.Add(new Game() { Name = "NFS ", GameStudioId = 2 });
            gameContext.SaveChanges();
        }

        private static void InitialStudies(GameContext gameContext)
        {
            gameContext.Studios.Add(new Studio() { Name = "EA" });
            gameContext.Studios.Add(new Studio() { Name = "GearBox " });
            gameContext.SaveChanges();
        }

        private static void InitialCategories(GameContext gameContext)
        {
            gameContext.Categories.Add(new Category() { Name = "РПГ" });
            gameContext.Categories.Add(new Category() { Name = "Квест" });
            gameContext.Categories.Add(new Category() { Name = "Гонка" });
            gameContext.SaveChanges();
        }
        private static void InitialGameCategories(GameContext gameContext)
        {
            gameContext.GameCategories.Add(new GameCategory() { CategoryId = 1, GameId = 1 });
            gameContext.GameCategories.Add(new GameCategory() { CategoryId = 2, GameId = 1 });
            gameContext.GameCategories.Add(new GameCategory() { CategoryId = 1, GameId = 2 });
            gameContext.GameCategories.Add(new GameCategory() { CategoryId = 3, GameId = 2 });
            gameContext.SaveChanges();
        }
    }
}
