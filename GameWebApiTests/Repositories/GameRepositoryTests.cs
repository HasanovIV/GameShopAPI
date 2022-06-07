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
using Microsoft.EntityFrameworkCore;
using GameWebApiTests.Common;

namespace GameWebApi.Repositories.Tests
{
    [TestClass()]
    public class GameRepositoryTests: TestCommandBase
    {

        [TestMethod()]
        public void GetTest()
        {
            // Init
            var game = new Game() {Name = "HMM3" };
            Context.Games.Add(game);
            Context.SaveChanges();

           var repository = new GameRepository(Context);

            // Act
            var resultGame = Context.Games.OrderBy(g => g.Id).LastOrDefault();
            var resultController = repository.Get(resultGame.Id);

            // Assert
            Assert.AreEqual(game.Name, resultController.Item1.Name);
        }
    }
}