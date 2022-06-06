using System;
using System.Collections.Generic;

namespace GameWebApi.Repositories.Interfaces
{
    public interface IBaseGameRepository<T> where T: class
    {
        public IEnumerable<T> GetAll();
        public object Get(int id);
        public T Create(T model);
        public T Update(T model);
        public bool Delete(int id);
    }
}
