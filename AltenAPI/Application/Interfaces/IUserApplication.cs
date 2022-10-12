using AltenAPI.Entities;
using AltenAPI.Models;

namespace AltenAPI.Application.Interfaces
{
    public interface IUserApplication
    {
        UserDto GetUser(UserLoginDto userLogin);
        int CreateUser(UserDto dto);
    }
}
