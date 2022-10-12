using AltenAPI.Models;

namespace AltenAPI.Services
{
    public interface ILoginService
    {
        IResult Login(UserDto loggedInUser);
    }
}
