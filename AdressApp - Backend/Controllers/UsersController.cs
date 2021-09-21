using AddressApp.BLL.DTOs.Users;
using AddressApp.BLL.Mappers.Users;
using AddressApp.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressApp___Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly IConfiguration configuration;
        public UsersController(IUsersService usersService, IConfiguration configuration)
        {
            this.usersService = usersService;
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult<List<GetAllUsersResponseDto>> Index()
        {
            return Ok(usersService.GetAllUsers()); 
        }

        [HttpPost, AllowAnonymous]
        public ActionResult<UserResponseDto> Create([FromForm]UserCreateRequestDto request)
        {
            var userRequest = UsersMapper.Map(request);
            userRequest.RootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            return Ok(usersService.CreateUser(userRequest));
        }

        [HttpPost(nameof(Login)), AllowAnonymous]
        public ActionResult<UserResponseDto> Login(UserLoginRequestDto request)
        {
            var userRequest = UsersMapper.Map(request);
            userRequest.RootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            return Ok(usersService.Login(userRequest));
        }

        [HttpGet("enable/{userId}")]
        public ActionResult Enable(int userId)
        {
            usersService.EnableUser(userId);
            return Ok();
        }

        [HttpGet("disable/{userId}")]
        public ActionResult Disable(int userId)
        {
            usersService.DisableUser(userId);
            return Ok();
        }

        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            usersService.DisableUser(userId);
            return Ok();
        }
    }
}
