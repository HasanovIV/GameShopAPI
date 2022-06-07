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

        /// <summary>
        /// Метод возвращает список всех игр
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Game>> Get()
        {
            return gameRepository.GetAll().ToList();
        }

        /// <summary>
        /// Метод возвращает информацию об игре (включая категории этой игры) по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<object> GetById(int id)
        {
            return gameRepository.Get(id);
        }
        
        /// <summary>
        /// Метод возвращает список игр по идентификатору категории.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("category/{id}")]
        public ActionResult<List<Game>> GamesByCategory(int id)
        {
            return gameService.GamesByCategory(id).ToList();
        }

        /// <summary>
        /// Метод создает новую игру из данных тела запроса
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод обновляет данные об игре (по данным в теле запроса)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод удаляет игру по идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            gameRepository.Delete(id);

            return new NoContentResult();
        }
    }
}
