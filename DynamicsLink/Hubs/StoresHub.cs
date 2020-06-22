using AutoMapper;
using DynamicsLink.Models.Entites;
using DynamicsLink.Models.Repositories;
using DynamicsLink.Resources;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicsLink.Hubs
{
    public class StoresHub:Hub
    {
        private readonly IItemRepository itemRepository;
        private readonly IUnitRepository unitRepository;
        private readonly IMapper mapper;

        public StoresHub(IItemRepository itemRepository,IUnitRepository unitRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.unitRepository = unitRepository;
            this.mapper = mapper;
        }

        public async Task GetItems(Guid storeId)
        {
            var items = itemRepository.GetAll(storeId);
            var resourse = mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);
            await Clients.All.SendAsync("SetItems", resourse);
        }

        public async Task GetItemUnits(Guid itemId,int index)
        {
            var units = unitRepository.GetAll(itemId);
            var resourse = mapper.Map<IEnumerable<Unit>, IEnumerable<UnitResource>>(units);
            await Clients.All.SendAsync("SetItemUnits", resourse, index);
        }
    }
}
