using GameWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GameWebApi.Database
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategory> GameCategories{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Studio> Studios{ get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            if (!Categories.Any())
            {
                InitialStudies();
                InitialCategories();
                InitialGames();
                InitialGameCategories();
            }
        }

        private void InitialGames()
        {
            Games.Add(new Game() { Name = "Ведьмак", GameStudioId = 1 });
            Games.Add(new Game() { Name = "NFS ", GameStudioId = 2 });
            this.SaveChanges();
        }

        private void InitialStudies()
        {
            Studios.Add(new Studio() { Name = "EA" });
            Studios.Add(new Studio() { Name = "GearBox "});
            this.SaveChanges();
        }

        private void InitialCategories()
        {
            Categories.Add(new Category() { Name = "РПГ"});
            Categories.Add(new Category() { Name = "Квест"});
            Categories.Add(new Category() { Name = "Гонка"});
            this.SaveChanges();
        }
        private void InitialGameCategories()
        {
            GameCategories.Add(new GameCategory() { CategoryId = 1, GameId = 1 });
            GameCategories.Add(new GameCategory() { CategoryId = 2, GameId = 1 });
            GameCategories.Add(new GameCategory() { CategoryId = 1, GameId = 2 });
            GameCategories.Add(new GameCategory() { CategoryId = 3, GameId = 2 });
            this.SaveChanges();
        }
    }
}
