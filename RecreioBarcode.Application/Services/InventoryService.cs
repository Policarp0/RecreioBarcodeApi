using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;
        public InventoryService(IInventoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<InventoryDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                 ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryDTO>(entity);
        }
        public async Task<IEnumerable<InventoryDTO>> GetAllActiveAsync()
        {
            var entities = await _repository.GetAllActiveAsync();            
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync()
        {
            var entities = await _repository.GetAllInactiveAsync();
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }
        public async Task CreateAsync(InventoryDTO dto)
        {
            var entity = _mapper.Map<Inventory >(dto);
            await _repository.CreateAsync(entity);
        }
        public async Task UpdateAsync(InventoryDTO dto)
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
