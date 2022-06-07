using GameWebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameWebApiTests.Common
{
    public class GameContextFactory
    {
        public static GameContext Create(bool withInit=false)
        {
            var options = new DbContextOptionsBuilder<GameContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            GameContext dbContext = new GameContext(options);
            
            if (withInit)
                InitialDatabase.InitialData(dbContext);

            return dbContext;
        }

        public static void Destroy(GameContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
