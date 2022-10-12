using AltenAPI.Application.Interfaces;
using AltenAPI.Models;
using AltenAPI.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;
using AltenAPI.Utils;
using AutoMapper;
using AltenAPI.Entities;

namespace AltenAPI.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository repository;
        private IMapper mapper;

        public UserApplication(IUserRepository _repository, IMapper _mapper)
        {
            this.repository = _repository;  
            this.mapper = _mapper;
        }

        public UserDto GetUser(UserLoginDto userLogin)
        {
            userLogin.Password = HashPassword.HashUserPassword(userLogin.Password);
            var user = repository.GetUser(userLogin).Result;
            return user;
        }

        public int CreateUser(UserDto dto)
        {
            var user = mapper.Map<User>(dto);
            user.Password = HashPassword.HashUserPassword(dto.Password);
            var result = repository.CreateUser(user);
            return result.Result;
        }
    }
}
