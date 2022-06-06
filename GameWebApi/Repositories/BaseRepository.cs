using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Repositories.Interfaces;
using GameWebApi.Database;
using GameWebApi.Models;

namespace GameWebApi.Repositories
{
    public class BaseRepository<T> : IBaseGameRepository<T> where T : class
    {
        protected GameContext Context { get; set; }

        public BaseRepository(GameContext gameContext)
        {
            Context = gameContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().Select(t => t);
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().FirstOrDefault(t => t.Equals((object)id));
        }

        public virtual T Create(T model)
        {
            Context.Set<T>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public virtual T Update(T model)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
