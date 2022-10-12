using AltenAPI.DbContexts;
using AltenAPI.Entities;
using AltenAPI.Models;
using AltenAPI.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AltenAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;
        private IMapper mapper;

        public UserRepository(ApplicationDbContext _db, IMapper _mapper)
        {
            this.db = _db;
            this.mapper = _mapper;
        }

        public async Task<UserDto> GetUser(UserLoginDto userLogin)
        {
            UserDto userDto = new UserDto();
            try
            {
                var user = await db.Users.Where(x => x.Username.Equals(userLogin.UserName) && x.Password.Equals(userLogin.Password)).FirstOrDefaultAsync();
                userDto = mapper.Map<UserDto>(user);
            }
            catch(Exception ex)
            {
                var mensagem = ex.Message;
            }
            return userDto;
        }

        public async Task<int> CreateUser(User user)
        {
            await db.Users.AddAsync(user);
            var inserted = await db.SaveChangesAsync();
            return inserted;
        }
    }
}
