using User.Models;

namespace dotnet_app.Services.User
{
    public interface IUserService
    {
        UserEntity CreateUser(UserEntity user);
    }
}