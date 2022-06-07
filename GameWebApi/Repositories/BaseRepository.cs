using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Repositories.Interfaces;
using GameWebApi.Database;
using GameWebApi.Models;

namespace GameWebApi.Repositories
{
    public class BaseRepository<TKey, TValue> : IBaseGameRepository<TKey, TValue> where TKey : class
    {
        protected GameContext Context { get; set; }

        public BaseRepository(GameContext gameContext)
        {
            Context = gameContext;
        }

        public virtual IEnumerable<TKey> GetAll()
        {
            return Context.Set<TKey>().Select(t => t);
        }

        /// <summary>
        /// Метод определен как базовый метод нахождения объекта.
        /// В основном этот метод переопределен для использования.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual (TKey, IEnumerable<TValue>) Get(int id)
        {
            TKey model = Context.Set<TKey>()
                .AsEnumerable()
                .FirstOrDefault(t => String.Equals(t.ToString(), id.ToString()));
            return (model, null);
        }

        public virtual TKey Create(TKey model)
        {
            Context.Set<TKey>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public virtual TKey Update(TKey model)
        {
            Context.Set<TKey>().Update(model);
            Context.SaveChanges();
            return model;
        }

        public virtual bool Delete(int id)
        {
            TKey model = Context.Set<TKey>()
                .AsEnumerable()
                .FirstOrDefault(t => String.Equals(t.ToString(), id.ToString()) );

            if (model != null)
            {
                Context.Set<TKey>().Remove(model);
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
