using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Auth;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AuthorizeWithToken]
        [HttpPost("users/post")]
        public ActionResult AddMember([FromBody] UserEntity user)
        {
            var userEntityWithToken = _userService.CreateUser(user);
            return Ok(userEntityWithToken);
        }
    }
}
