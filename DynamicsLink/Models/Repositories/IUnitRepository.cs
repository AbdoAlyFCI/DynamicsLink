using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public interface IUnitRepository : IRepository<Unit>
    {
        IEnumerable<Unit> GetAll(Guid itemId);
    }
}
