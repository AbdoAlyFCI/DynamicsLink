using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Entites
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
