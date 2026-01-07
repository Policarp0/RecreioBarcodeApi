using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecreioBarcode.Application.Services
{
    public class InventoryLocationService : IInventoryLocationService
    {
        private readonly IInventoryLocationRepository _repository;
        private readonly IMapper _mapper;
        public InventoryLocationService(IInventoryLocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<InventoryLocationDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                 ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryLocationDTO>(entity);
        }
        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByInventoryIdAsync(int inventoryId)
        {
            var entities = await _repository.GetAllByInventoryIdAsync(inventoryId);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }
        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByEstanteAsync(int inventoryId, char estante)
        {
            var entities = await _repository.GetAllByEstanteAsync(inventoryId, estante);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByNumeroAsync(int inventoryId, char numero)
        {
            var entities = await _repository.GetAllByNumeroAsync(inventoryId, numero);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByPrateleiraAsync(int inventoryId, char prateleira)
        {
            var entities = await _repository.GetAllByPrateleiraAsync(inventoryId, prateleira);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByRuaAsync(int inventoryId, char rua)
        {
            var entities = await _repository.GetAllByRuaAsync(inventoryId, rua);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLocationDTO>> GetAllByZonaAsync(int inventoryId, char zona)
        {
            var entities = await _repository.GetAllByZonaAsync(inventoryId, zona);
            return _mapper.Map<IEnumerable<InventoryLocationDTO>>(entities);
        }

        public async Task CreateAsync(InventoryLocationDTO dto)
        {
            var entity = _mapper.Map<InventoryLocation>(dto);
            await _repository.CreateAsync(entity);
        }
        public async Task UpdateAsync(InventoryLocationDTO dto)
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
