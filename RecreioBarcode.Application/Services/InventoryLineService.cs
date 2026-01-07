using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class InventoryLineService : IInventoryLineService
    {
        private readonly IInventoryLineRepository _repository;
        private readonly IMapper _mapper;
        public InventoryLineService(IInventoryLineRepository service, IMapper mapper)
        {
            _repository = service;
            _mapper = mapper;
        }
        public async Task<InventoryLineDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryLineDTO>(entity);
        }
        public async Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryIdAsync(int inventoryId)
        {
            var entities = await _repository.GetAllByInventoryIdAsync(inventoryId);
            return _mapper.Map<IEnumerable<InventoryLineDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryLocationIdAsync(int inventoryLocationId)
        {
            var entities = await _repository.GetAllByInventoryLocationIdAsync(inventoryLocationId);
            return _mapper.Map<IEnumerable<InventoryLineDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryLineDTO>> GetAllByInventoryLocationRangeAsync(int inventoryId, char zonaInitial, char zonaFinal, int ruaInicial, int ruaFinal, int estanteInitial, int estanteFinal, char prateleiraInitial, char prateleiraFinal, int numeroInitial, int numeroFinal)
        {
            var entities = await _repository.GetAllByInventoryLocationRangeAsync(
                inventoryId,
                zonaInitial, zonaFinal, 
                ruaInicial, ruaFinal,
                estanteInitial, estanteFinal, 
                prateleiraInitial, prateleiraFinal,
                numeroInitial, numeroFinal);
            return _mapper.Map<IEnumerable<InventoryLineDTO>>(entities);
        }
        public async Task CreateAsync(InventoryLineDTO dto)
        {
            var entity = _mapper.Map<InventoryLine>(dto);
            await _repository.CreateAsync(entity);
        }
        public async Task UpdateAsync(InventoryLineDTO dto)
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
