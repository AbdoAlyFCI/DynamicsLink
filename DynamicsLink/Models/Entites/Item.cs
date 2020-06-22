using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Entites
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }


        public Guid StoreId { get; set; }

        public Store Store { get; set; }


        public ICollection<Unit> Units { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}
