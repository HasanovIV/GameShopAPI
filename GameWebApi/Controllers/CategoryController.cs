using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Models;
using GameWebApi.Repositories;
using GameWebApi.Repositories.Interfaces;
using GameWebApi.Services.Interfaces;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private IBaseGameRepository<Category> gameRepository { get; set; }

        public CategoryController(IBaseGameRepository<Category> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return gameRepository.GetAll().ToList();
        }
    }
}
