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
        public async Task<InventoryItemOutDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryItemOutDTO>(entity);
        }
        public async Task<IEnumerable<InventoryItemOutDTO>> GetAllByInventoryId(int inventoryId)
        {
            var entities = await _repository.GetAllByInventoryIdAsync(inventoryId);
            return _mapper.Map<IEnumerable<InventoryItemOutDTO>>(entities);
        }
        public async Task CreateAsync(InventoryItemOutDTO dto)
        {
            var entity = _mapper.Map<InventoryItemOut>(dto);
            await _repository.CreateAsync(entity);
        }
        public async Task UpdateAsync(InventoryItemOutDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            await _repository.DeleteAsync(entity);
        }






    }
}
