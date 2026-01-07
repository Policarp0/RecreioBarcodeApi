using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return null;
            return _mapper.Map<UserDTO>(entity);
        }
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(entities);
        }
        public async Task CreateAsync(UserDTO dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _repository.CreateAsync(entity);

        }
        public async Task UpdateAsync(UserDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity is null)
                throw new KeyNotFoundException("Usuário não foi encontrado");
            else
            {
                entity = _mapper.Map(dto, entity);
                await _repository.UpdateAsync(entity);
            }    
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                throw new KeyNotFoundException("Usuário não foi encontrado");
            else
                await _repository.DeleteAsync(entity);
        }
    }
}
