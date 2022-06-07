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

        /// <summary>
        /// Метод определен как базовый метод нахождения объекта.
        /// В основном этот метод переопределен для использования.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual object Get(int id)
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
            Context.Set<T>().Update(model);
            Context.SaveChanges();
            return model;
        }

        public virtual bool Delete(int id)
        {
            T model = Context.Set<T>().FirstOrDefault(t => t.Equals((object)id));
            if (model != null)
            {
                Context.Set<T>().Remove(model);
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
