using dotnet_app.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_app.Shared
{
    public static class Startup
    {

        private static void Setup(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString =
            builder.Configuration.GetConnectionString("PostgresDB") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            ServiceRegistration.RegisterServices(builder.Services);

        }

        private static WebApplication Build(WebApplicationBuilder builder)
        {
            var app = builder.Build();
            return app;

        }

        public static void Run(WebApplicationBuilder builder)
        {
            Setup(builder);
            var app = Build(builder);

            // checked connection to database
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Database.CanConnect().Equals(true))
                {
                    dbContext.Database.EnsureCreated();
                    Console.WriteLine("Successfully connected to PostgreSQL database.");
                }
                else
                {
                    throw new InvalidOperationException("Failed to connect to PostgreSQL database.");
                }
            }

            // checked Environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
