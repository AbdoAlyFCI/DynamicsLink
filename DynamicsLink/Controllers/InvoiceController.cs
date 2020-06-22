using AutoMapper;
using DynamicsLink.Models.Repositories;
using DynamicsLink.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController:ControllerBase
    {
        private readonly IInvoiceRepository repo;
        private readonly IMapper mapper;

        public InvoiceController(IInvoiceRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpPost]
        public InvoiceResource CreateInvoice(InvoiceResource resource)
        {
            return resource;
        }
    }
}
