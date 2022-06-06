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
    public class GameController: ControllerBase
    {
        private IBaseGameRepository<Game> gameRepository{ get; set; }
        private IGameService gameService{ get; set; }

        public GameController(IBaseGameRepository<Game> gameRepository, IGameService gameService)
        {
            this.gameRepository = gameRepository;
            this.gameService = gameService;
        }

        [HttpGet]
        public ActionResult<List<Game>> Get()
        {
            return gameRepository.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<object> GetById(int id)
        {
            return gameRepository.Get(id);
        }
        
        [HttpGet("category/{id}")]
        public ActionResult<List<Game>> GamesByCategory(int id)
        {
            return gameService.GamesByCategory(id).ToList();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Game item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            gameRepository.Create(item);

            return new NoContentResult();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Game item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            gameRepository.Update(item);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            gameRepository.Delete(id);

            return new NoContentResult();
        }
    }
}
