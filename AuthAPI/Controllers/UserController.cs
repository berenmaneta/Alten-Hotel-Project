using AltenAPI.Application.Interfaces;
using AltenAPI.Models;
using AltenAPI.Services;
using AltenAPI.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static AltenAPI.Utils.MessageEnums;

namespace AltenAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors("CorsAlten")]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserApplication application;
        private readonly ILoginService loginService;

        public UserController(IUserApplication _application, ILoginService _loginService)
        {
            this.application = _application;
            this.loginService = _loginService;
        }

        [HttpPost("login")]
        public IResult Login(UserLoginDto user)
        {
            if (!string.IsNullOrEmpty(user.UserName) &&
                !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = application.GetUser(user);
                var login = loginService.Login(loggedInUser);

                return login;
            }
            return Results.BadRequest("Invalid user credentials");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpPost("create")]
        public IResult Login(UserDto dto)
        {
            var user = application.CreateUser(dto);
            return Results.Ok(MessageEnums.GetEnumDescription((CreateUserMessageEnum)user));
        }

    }
}
