using System;
using System.Collections.Generic;
using GameWebApi.Models;

namespace GameWebApi.Services.Interfaces
{
    public interface IGameService
    {
        IEnumerable<Game> GamesByCategory(int categoryId);
    }
}
