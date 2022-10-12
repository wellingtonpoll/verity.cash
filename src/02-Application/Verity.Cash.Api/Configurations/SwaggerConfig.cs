using Microsoft.OpenApi.Models;

namespace Verity.Cash.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Verity Cash Management",
                    Description = "Architecture Test",
                    Contact = new OpenApiContact { Name = "Wellington Luiz do Nascimento", Email = "wellingtonpoleti@gmail.com", Url = new Uri("https://www.linkedin.com/in/wellington-luiz-do-nascimento/") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/wellingtonpoll/verity.cash/blob/main/LICENSE") }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}