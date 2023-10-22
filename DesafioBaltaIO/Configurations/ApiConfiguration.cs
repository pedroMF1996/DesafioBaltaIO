using DesafioBaltaIO.Data.IBGE;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DesafioBaltaIO.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddRegisterServices();

            services.AddDbContext<IbgeDbContext>(opt =>
                opt.UseSqlite(configuration.GetConnectionString("DesafioBaltaIOSqliteConnection")));

            services.AddIdentityConfiguration(configuration, environment);

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();

            services.AddCustomValidationClaim();

            services.AddCors(opt =>
            {
                opt.AddPolicy("total",builder => 
                    builder.AllowAnyHeader()
                           .AllowAnyOrigin()
                           .AllowAnyMethod());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseSwaggerConfiguration(environment);
            app.UseHttpsRedirection();
            app.UseCors("total");
            app.UseAuthConfiguration();

            return app;
        }
    }
}
