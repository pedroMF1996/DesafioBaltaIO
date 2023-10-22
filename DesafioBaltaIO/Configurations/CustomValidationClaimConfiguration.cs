namespace DesafioBaltaIO.Configurations
{
    public static class CustomValidationClaimConfiguration
    {
        public static IServiceCollection AddCustomValidationClaim(this IServiceCollection services)
        {
            services
                .AddAuthorization(opt =>
                {
                    opt.AddPolicy("IBGE_Cadastrar", policy =>
                    {
                        policy.RequireClaim("IBGE_Cadastrar", "permitido");
                    });

                    opt.AddPolicy("IBGE_Atualizar", policy =>
                    {
                        policy.RequireClaim("IBGE_Atualizar", "permitido");
                    });

                    opt.AddPolicy("IBGE_Remover", policy =>
                    {
                        policy.RequireClaim("IBGE_Remover", "permitido");
                    });
                });

            return services;
        }
    }
}
