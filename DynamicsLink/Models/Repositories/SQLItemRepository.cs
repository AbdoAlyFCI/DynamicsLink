using DynamicsLink.Models.Context;
using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly AppDbContext context;

        public SQLItemRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Item item)
        {
            throw new NotImplementedException();
        }

        public Item Get(Guid id)
        {
            var item = context.Items.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public IEnumerable<Item> GetAll()
        {
            return context.Items;
        }

        public IEnumerable<Item> GetAll(Guid storeId)
        {
            return context.Items.Where(i => i.StoreId == storeId).ToList();
        }
    }
}
