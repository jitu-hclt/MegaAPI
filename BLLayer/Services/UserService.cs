using System;
using AutoMapper;
using BusinessEntities.Models;
using DALayer.Repositories;
using DALayer.RepositoryUOW;
using ModelDTOs.Models;

namespace BLLayer.Services
{
	public class UserService : IUserService
    {
        private IUserRepository _userRepo;
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _userRepo = uow.UserRepository;
            _mapper = mapper;
        }

        public UserDTO Validate(string Email, string Password)
        {
            return _mapper.Map<UserDTO>(_userRepo.ValidateUser(new User { Email = Email, Password = Password }));
        }
    }
}

