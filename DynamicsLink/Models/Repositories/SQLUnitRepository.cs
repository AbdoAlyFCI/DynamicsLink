using DynamicsLink.Models.Context;
using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public class SQLUnitRepository : IUnitRepository
    {
        private readonly AppDbContext context;

        public SQLUnitRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Unit item)
        {
            throw new NotImplementedException();
        }

        public Unit Get(Guid id)
        {
            var unit = context.Units.FirstOrDefault(u => u.Id == id);
            return unit;
        }

        public IEnumerable<Unit> GetAll()
        {
            return context.Units;
        }

        public IEnumerable<Unit> GetAll(Guid itemId)
        {
            return context.Units.Where(u => u.ItemId == itemId).ToList();
        }
    }
}
