using DesafioBaltaIO.Data.Atenticacao;
using DesafioBaltaIO.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesafioBaltaIO.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("AutenticacaoSqlServerConnection")));


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
