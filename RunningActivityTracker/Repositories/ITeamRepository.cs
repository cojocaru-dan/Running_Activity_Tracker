using System.Collections.Generic;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Repositories
{
    public interface ITeamRepository
    {
        TeamEntity FindTeamByAdmin(string userName);
        TeamEntity FindTeamByMember(string userName);
        void CreateTeam(TeamEntity team);
        void Clear();
        void AddTeamMember(TeamEntity team, UserEntity member);
        IEnumerable<TeamEntity> GetAll();
    }
}
