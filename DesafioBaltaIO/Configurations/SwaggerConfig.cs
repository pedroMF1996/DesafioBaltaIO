namespace DesafioBaltaIO.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Desafio Balta.IO API",
                        Description = "Essa API faz parte de um desafio proposto pelo Andre Baltieri no dia 10/10/2023",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Pedro Falleiros", Email = "pmfrp@hotmail.com" },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                    });

                    c.AddSwaggerJwtAuthorizationConfiguration();    
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            return app;
        }
    }
}
