using DesafioBaltaIO.Data.Atenticacao;
using DesafioBaltaIO.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesafioBaltaIO.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string connectionString = "";
            if (environment.IsProduction())
            {
                connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";
            }
            if (environment.IsDevelopment())
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlite(configuration.GetConnectionString("AutenticacaoSqliteConnection")));


            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            //JWT
            services.AddJwtConfiguration(configuration);

            return services;
        }
    }
}
