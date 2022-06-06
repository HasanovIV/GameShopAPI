using GameWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameWebApi.Database
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenres{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios{ get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
