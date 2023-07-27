using System.Collections.Generic;

namespace RunningActivityTracker.Entities
{
    public class TeamEntity
    {
        public string Name { get; set; }
        public UserEntity Admin { get; set; }
        public List<UserEntity> Members { get; set; }

        public TeamEntity(string name, List<UserEntity> members, UserEntity admin)
        {
            Name = name;
            Members = members;
            Admin = admin;
        }
    }
}
