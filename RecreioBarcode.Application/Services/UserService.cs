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

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
