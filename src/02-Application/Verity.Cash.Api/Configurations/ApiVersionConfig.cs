using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Verity.Cash.Api.Configurations
{
    public static class ApiVersionConfig
    {
        public static void AddApiVersionConfiguration(this IServiceCollection services)
        {
            services.AddMvc(c => c.EnableEndpointRouting = false);
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(2, 1);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
        }

        public static void UseApiVersionSetup(this IApplicationBuilder app)
        {
            app.UseMvc()
                .UseApiVersioning()
                .UseMvcWithDefaultRoute();
            
            app.UseSwaggerSetup(app.ApplicationServices.GetService<IApiVersionDescriptionProvider>());
        }
    }
}