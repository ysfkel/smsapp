using DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class Decorator<T> : GenericRepository<T> where T : class
    {

        public Decorator(IDbConnection Db) : base(Db)
        {
        }

    }
}
