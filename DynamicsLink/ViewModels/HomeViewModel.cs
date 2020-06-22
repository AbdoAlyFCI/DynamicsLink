using DynamicsLink.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<StoreResource> Stores { get; set; }
        public int InvoiceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
