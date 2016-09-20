using System;
using System.Collections.Generic;
using System.Data;
using ServiceStack.OrmLite;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
      where T : class
    {
        private readonly IDbConnection _databaseContext;

        public GenericRepository(IDbConnection databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<T> Get()
        {
          return _databaseContext.Select<T>();
        }

        public async Task<T> GetByID(int id)
        {
            return await _databaseContext.SingleByIdAsync<T>(id);
        }
        public int Add(T p)
        {
            return (int)_databaseContext.Insert<T>(p, selectIdentity: true);
        }

    }
}
