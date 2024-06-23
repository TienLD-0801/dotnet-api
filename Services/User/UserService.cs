using dotnet_app.Data;
using User.Models;

namespace dotnet_app.Services.User
{
    public class UserService(ApplicationDbContext dbContext) : IUserService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public UserEntity CreateUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
