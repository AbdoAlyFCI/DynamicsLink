using DynamicsLink.Models.Context;
using DynamicsLink.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Repositories
{
    public class SQLInvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext context;

        public SQLInvoiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Invoice item)
        {
            context.Invoices.Add(item);
            context.SaveChanges();
        }

        public Invoice Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetNewID()
        {
            var lastItem = context.Invoices.Count();
            if (lastItem==0)
                return 1;

            return context.Invoices.LastOrDefault().Number + 1;
        }
    }
}
