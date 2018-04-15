using System;
using System.Threading.Tasks;
using AutoMapper;
using PB.Core.Models;
using PB.Core.Repositories;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> LoginAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("User with this email doesn't exist.");
            }

            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task RegisterAsync(string email, string password, string username)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception("User with this email already exists.");
            }
            
            var salt = new Guid().ToString();
            user = new User(username, email, password, salt);
            await _userRepository.AddAsync(user);
        }
    }
}