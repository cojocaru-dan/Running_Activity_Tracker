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
        // add verb and route
        public ActionResult AddMember([FromBody] UserEntity user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
    }
}
