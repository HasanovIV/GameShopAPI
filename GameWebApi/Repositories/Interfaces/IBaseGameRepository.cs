using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameWebApi.Repositories.Interfaces
{
    public interface IBaseGameRepository<T> where T: class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public T Create(T model);
        public T Update(T model);
        public void Delete(int id);
    }
}
