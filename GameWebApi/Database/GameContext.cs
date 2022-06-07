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
            Database.EnsureCreated();
            InitialDatabase.InitialData(this);
        }

    }
}
