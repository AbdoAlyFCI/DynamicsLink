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
    public class UnitController: ControllerBase
    {
        private readonly IUnitRepository unitRepo;
        private readonly IMapper mapper;

        public UnitController(IUnitRepository unitRepo,IMapper mapper)
        {
            this.unitRepo = unitRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<UnitResource> GetUnit(Guid itemId)
        {
            var items = unitRepo.GetAll(itemId);
            var resourse = mapper.Map<IEnumerable<Unit>, IEnumerable<UnitResource>>(items);
            return resourse;
        }
    }
}
