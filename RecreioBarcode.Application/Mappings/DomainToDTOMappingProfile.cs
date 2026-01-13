using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Domain.Entities;

namespace RecreioBarcode.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Inventory,InventoryDTO>().ReverseMap();
            CreateMap<UpdateInventoryDTO, Inventory>()
                .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InventoryItemOut,InventoryItemOutDTO>().ReverseMap();
            CreateMap<InventoryLine,InventoryLineDTO>().ReverseMap();
            CreateMap<InventoryLocation,InventoryLocationDTO>().ReverseMap();
            CreateMap<Location,LocationDTO>().ReverseMap();
        }
    }
}
