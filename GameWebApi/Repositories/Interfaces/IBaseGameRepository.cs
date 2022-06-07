using System;
using System.Collections.Generic;

namespace GameWebApi.Repositories.Interfaces
{
    public interface IBaseGameRepository<TKey, TValue> where TKey: class
    {
        public IEnumerable<TKey> GetAll();
        public (TKey, IEnumerable<TValue>) Get(int id);
        public TKey Create(TKey model);
        public TKey Update(TKey model);
        public bool Delete(int id);
    }
}
