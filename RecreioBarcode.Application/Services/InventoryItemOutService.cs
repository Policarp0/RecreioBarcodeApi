using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class InventoryItemOutService : IInventoryItemOutService
    {
        private readonly IInventoryItemOutRepository _repository;
        private readonly IMapper _mapper;
        public InventoryItemOutService(IInventoryItemOutRepository service, IMapper mapper)
        {
            _repository = service;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InventoryItemOutDTO>> GetAllByInventoryId(int inventoryId)
        {
            var entities = await _repository.GetAllByInventoryIdAsync(inventoryId);
            return _mapper.Map<IEnumerable<InventoryItemOutDTO>>(entities);
        }
    }
}
