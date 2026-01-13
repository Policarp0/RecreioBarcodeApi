
using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;
        public LocationService(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<LocationDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LocationDTO?> GetByDetailsAsync(char zona, int rua, int estante, char prateleira, int numero)
        {
            throw new NotImplementedException();
        }
    }
}
