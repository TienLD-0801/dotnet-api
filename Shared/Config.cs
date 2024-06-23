using dotnet_app.Services.User;
namespace dotnet_app.Shared
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
