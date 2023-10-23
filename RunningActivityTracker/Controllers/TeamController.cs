using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunningActivityTracker.Entities;
using RunningActivityTracker.Services;

namespace RunningActivityTracker.Controllers
{

    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IUserService _userService;

        public TeamController(ITeamService teamService, IUserService userService)
        {
            _teamService = teamService;
            _userService = userService;
        }

        [HttpPost("/team")]
        // add auhtorization here
        [Authorize(Roles = "User")]
        public ActionResult CreateTeam([FromBody] string teamName)
        {
            var currentUserName = HttpContext.User.Identity.Name;
            var currentUser = _userService.GetAll().Where(user => user.Username == currentUserName).FirstOrDefault();
            var newTeamEntity = _teamService.CreateTeam(teamName, currentUser);
            return Ok(newTeamEntity);
        }

        [HttpPut("/team/members")]
        // add authorization here
        [Authorize(Roles = "TeamAdmin")]
        public ActionResult AddMember([FromBody] string memberName)
        {
            var currentAdminName = HttpContext.User.Identity.Name;
            var currentAdmin = _userService.GetAll().Where(user => user.Username == currentAdminName).FirstOrDefault();
            var getMember = _userService.GetAll().Where(user => user.Username == memberName).FirstOrDefault();
            if (getMember == null) return NotFound();
            var teamWithNewMember = _teamService.AddMember(getMember, currentAdmin);
            return Ok(teamWithNewMember);
        }
    }
}
