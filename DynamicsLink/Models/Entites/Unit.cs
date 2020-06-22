using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Models.Entites
{
    public class Unit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quntity { get; set; }

        [Range(0,1)]
        public float Discount { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
