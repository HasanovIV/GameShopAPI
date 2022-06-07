using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameWebApi.Services;
using System;
using GameWebApi.Models;
using GameWebApiTests.Common;
using System.Linq;

namespace GameWebApi.Services.Tests
{
    [TestClass()]
    public class GameServiceTests: TestCommandBase
    {
        [TestMethod()]
        public void GamesByCategoryTest()
        {
            // Init
            var _game = new Game() { Name = "HMM3" };
            Context.Games.Add(_game);

            var category = new Category() { Name = "category HMM3" };
            Context.Categories.Add(category);

            Context.SaveChanges();

            var resultGame = Context.Games.OrderBy(g => g.Id).LastOrDefault();
            var resultCategory = Context.Categories.OrderBy(g => g.Id).LastOrDefault();

            var gameCategory = new GameCategory() { GameId = resultGame.Id, CategoryId = resultCategory.Id };
            Context.GameCategories.Add(gameCategory);

            Context.SaveChanges();

            var gameService = new GameService(Context);

            // Act
            var _resultService = gameService.GamesByCategory(resultCategory.Id);

            // Assert
            Assert.IsTrue(_resultService.Count() == 1);
            Assert.AreEqual(_game.Name, _resultService.ToList()[0].Name);
        }
    }
}