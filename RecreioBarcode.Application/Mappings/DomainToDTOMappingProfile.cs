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
            CreateMap<InventoryItemOut,InventoryItemOutDTO>().ReverseMap();
            CreateMap<InventoryLine,InventoryLineDTO>().ReverseMap();
            CreateMap<InventoryLocation,InventoryLocationDTO>().ReverseMap();
            CreateMap<Location,LocationDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
        }
    }
}
