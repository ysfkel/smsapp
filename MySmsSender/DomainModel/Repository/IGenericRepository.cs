using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repository
{
    public interface IGenericRepository<T>
    {
        int Add(T t);
        List<T> Get();
        Task<T> GetByID(int id);
    }
}
