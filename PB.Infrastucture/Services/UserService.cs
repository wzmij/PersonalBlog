using System;
using System.Threading.Tasks;
using AutoMapper;
using PB.Core.Models;
using PB.Core.Repositories;
using PB.Infrastucture.DTO;
using PB.Infrastucture.Extenstions;

namespace PB.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetOrFailAsync(email);

            var hash = _encrypter.GetHash(password, user.Salt);
            if(hash == user.Password)
            {
                return;
            }
            throw new Exception("Invalid credentials.");
        }

        public async Task RegisterAsync(Guid userId, string email, string password, string username)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, username, email, hash, salt, Roles.User);
            await _userRepository.AddAsync(user);
        }
    }
}