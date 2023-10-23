using System.Collections.Generic;

namespace RunningActivityTracker.Entities
{
    public class TeamEntity
    {
        public string Name { get; set; }
        public UserEntityWithToken Admin { get; set; }
        public List<UserEntityWithToken> Members { get; set; }

        public TeamEntity(string name, List<UserEntityWithToken> members, UserEntityWithToken admin)
        {
            Name = name;
            Members = members;
            Admin = admin;
        }
    }
}
