using System.Collections.Generic;
using System.Threading.Tasks;
using RunningActivityTracker.Entities;

namespace RunningActivityTracker.Services
{
    public interface IUserService
    {
        UserEntityWithToken FindCurrentUser();
        UserEntityWithToken CreateUser(UserEntity user);
        Task<UserEntityWithToken> AuthenticateAsync(string userName, string password);
        IEnumerable<UserEntityWithToken> GetAll();
    }
}
