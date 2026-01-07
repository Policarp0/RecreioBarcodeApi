
using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LocationDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<LocationDTO>(entity);
        }

        public async Task<IEnumerable<LocationDTO>> GetAllAsync()
        {
            var entites = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LocationDTO>>(entites);
        }

        public async Task<LocationDTO?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero)
        {
            var entity = await _repository.GetByDetailsAsync(zona, rua, estante, prateleira, numero)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<LocationDTO>(entity);
        }

        public async Task CreateAsync(LocationDTO dto)
        {
            var entity = _mapper.Map<Location>(dto);
            await _repository.CreateAsync(entity);
        }
        public async Task UpdateAsync(LocationDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            _mapper.Map(dto,entity);
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
