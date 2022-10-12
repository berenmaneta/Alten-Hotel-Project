using AltenAPI.Entities;
using AltenAPI.Models;

namespace AltenAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUser(UserLoginDto userLogin);
        Task<int> CreateUser(User user);
    }
}
