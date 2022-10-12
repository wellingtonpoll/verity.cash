using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Verity.Cash.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v2", CreateOpenApiInfo("v2"));
                s.SwaggerDoc("v1", CreateOpenApiInfo("v1", true));
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions.OrderByDescending(c => c.ApiVersion))
                {
                    c.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                }

                c.DocExpansion(DocExpansion.List);

                c.RoutePrefix = String.Empty;
            });
        }

        private static OpenApiInfo CreateOpenApiInfo(string version, bool deprecated = false)
        {
            return new OpenApiInfo
            {
                Version = version,
                Title = "Verity Cash Management" + (deprecated ? "- Deprecated" : ""),
                Description = "Architecture Test",
                Contact = new OpenApiContact { Name = "Wellington Luiz do Nascimento", Email = "wellingtonpoleti@gmail.com", Url = new Uri("https://www.linkedin.com/in/wellington-luiz-do-nascimento/") },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/wellingtonpoll/verity.cash/blob/main/LICENSE") }
            };
        }
    }
}