using System.Collections.Generic;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public class TeamService : ITeamService
    {
        public List<TeamEntity> teamRepo = new();
        public TeamEntity CreateTeam(string teamName, UserEntityWithToken currentUser)
        {
            var newTeamEntity = new TeamEntity(teamName, new List<UserEntityWithToken>() { currentUser }, currentUser);
            teamRepo.Add(newTeamEntity);
            return newTeamEntity;
        }
        public TeamEntity AddMember(UserEntityWithToken newMember, UserEntityWithToken admin)
        {
            var adminTeam = teamRepo.Find(t => t.Admin.Token == admin.Token);
            adminTeam ??= new TeamEntity($"{admin.Username}Team", new List<UserEntityWithToken>() { admin }, admin);
            adminTeam.Members.Add(newMember);
            return adminTeam;
        }
        public IEnumerable<TeamEntity> GetAll() { return teamRepo; }
    }
}