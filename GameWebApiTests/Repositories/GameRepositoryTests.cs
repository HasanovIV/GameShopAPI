using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GameWebApiTests.Mock;
using GameWebApi.Repositories;
using GameWebApi.Database;
using GameWebApi.Services;
using GameWebApi.Controllers;
using System.Linq;
using GameWebApi.Models;

namespace GameWebApi.Repositories.Tests
{
    [TestClass()]
    public class GameRepositoryTests
    {
        [TestMethod()]
        public void GetTest()
        {
            // Init
            var dbContext = new GameContext();
            MockInitialDatabase.InitialData(dbContext);

            var repository = new GameRepository(dbContext);

            // Act
            var resultController = repository.Get(1);
            var resultDb = dbContext.Games.SingleOrDefault(g => g.Id == 1);

            // Assert
            Assert.IsNotNull(resultDb);
            Assert.AreEqual(resultDb.Name, resultController.Item1.Name);
        }
    }
}