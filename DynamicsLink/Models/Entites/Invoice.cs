using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Entites
{
    public class Invoice
    {
        [Key]
        public int Number { get; set; }
        public DateTime date { get; set; }
        public float Total { get; set; }
        public float Taxes { get; set; }
        public float Net { get; set; }

        public Guid StoreId { get; set; }
        public Store Store { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
