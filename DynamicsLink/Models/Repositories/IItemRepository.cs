using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public interface IItemRepository :IRepository<Item>
    {
        IEnumerable<Item> GetAll(Guid storeId);
    }
}
