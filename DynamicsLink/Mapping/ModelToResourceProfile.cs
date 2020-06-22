using AutoMapper;
using DynamicsLink.Models.Entites;
using DynamicsLink.Resources;

namespace DynamicsLink.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Store, StoreResource>();
            CreateMap<Item, ItemResource>();
            CreateMap<Unit, UnitResource>();
        }
    }
}
