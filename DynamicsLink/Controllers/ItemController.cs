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
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController: ControllerBase
    {
        private readonly IItemRepository repo;
        private readonly IMapper mapper;

        public ItemController(IItemRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ItemResource> GetItems(Guid storeId)
        {
            var items = repo.GetAll(storeId);
            var resourse = mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);
            return resourse;
        }
    }
}
