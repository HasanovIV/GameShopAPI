using GameWebApi.Models;
using System;
using System.Collections.Generic;

namespace GameWebApiTests.Mock
{
    public class MockGameContext
    {
        public List<Game> Games { get; set; }
        public List<GameCategory> GameCategories { get; set; }
        public List<Category> Categories { get; set; }
        public List<Studio> Studios { get; set; }
    }
}
