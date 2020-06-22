using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Resources
{
    public class InvoiceResource
    {
        public int Number { get; set; }
        public DateTime date { get; set; }
        public float Total { get; set; }
        public float Taxes { get; set; }
    }
}
