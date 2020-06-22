using DynamicsLink.Models.Context;
using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public class SQLStoreRepository : IStoreRepository
    {
        private readonly AppDbContext context;

        public SQLStoreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Store item)
        {
            throw new NotImplementedException();
        }

        public Store Get(Guid id)
        {
            var store = context.Stores.FirstOrDefault(s => s.Id == id);
            return store;
        }

        public IEnumerable<Store> GetAll()
        {
            return context.Stores;
        }
    }
}
