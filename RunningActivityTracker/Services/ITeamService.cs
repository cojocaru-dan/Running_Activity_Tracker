using System.Collections.Generic;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public interface ITeamService
    {
        TeamEntity CreateTeam(string teamName, UserEntityWithToken currentUser);
        TeamEntity AddMember(UserEntityWithToken newMember, UserEntityWithToken admin);
        IEnumerable<TeamEntity> GetAll();
    }
}
