using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DynamicsLink.Models;
using DynamicsLink.Models.Repositories;
using AutoMapper;
using DynamicsLink.Models.Entites;
using DynamicsLink.Resources;
using DynamicsLink.ViewModels;

namespace DynamicsLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository storeRepo;
        private readonly IInvoiceRepository invoiceRepo;
        private readonly IMapper mapper;

        public HomeController(IStoreRepository storeRepo
                             ,IInvoiceRepository invoiceRepo
                             ,IMapper mapper)
        {
            this.storeRepo = storeRepo;
            this.invoiceRepo = invoiceRepo;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var stores = storeRepo.GetAll();
            var storeResource = mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);
            var newId = invoiceRepo.GetNewID();

            HomeViewModel model = new HomeViewModel()
            {
                Stores = storeResource,
                InvoiceNum = newId,
                InvoiceDate = DateTime.Now
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
