using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public interface IRepository<T>
    {
        void Create(T item);
        T Get(Guid id);

        IEnumerable<T> GetAll();
    }
}
