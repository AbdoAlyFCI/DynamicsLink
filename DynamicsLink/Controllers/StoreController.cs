using AutoMapper;
using DynamicsLink.Models.Context;
using DynamicsLink.Models.Entites;
using DynamicsLink.Models.Repositories;
using DynamicsLink.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StoreController: ControllerBase
    {

        private readonly IStoreRepository repo;
        private readonly IMapper mapper;

        public StoreController(IStoreRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StoreResource> getAll()
        {
            var stores = repo.GetAll();
            var resource = mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);
            return resource;
        }
    }
}
