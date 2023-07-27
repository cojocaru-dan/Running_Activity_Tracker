using System.Collections.Generic;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Repositories
{
    public interface IUserRepository
    {
        UserEntity FindUserByName(string userName);
        void CreateUser(UserEntity user);
        IEnumerable<UserEntity> GetAll();
        void Clear();
    }
}
