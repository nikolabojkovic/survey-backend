using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Survey.Extensions
{
    public static partial class StartupExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                string version = Assembly.GetEntryAssembly().GetName().Version.ToString();
                options.SwaggerDoc($"v{version}", new Info
                {
                    Version = version,
                    Title = "Intelisale Survey API",
                    Description = "You may use this API to integrate with user microservice.",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Provendu Team", Email = "dev@intelisale.com", Url = "http://intelisale.com" },
                    License = new License { Name = "Use under LICX", Url = "http://intelisale.com" }
                });

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] {} }
                });

                var location = Assembly.GetEntryAssembly().Location;
                var directory = Path.GetDirectoryName(location);
                options.IncludeXmlComments($@"{directory}/{Assembly.GetEntryAssembly().GetName().Name}.xml");
            });
        }

        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            string version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            app.UseSwagger(c => c.RouteTemplate = "survey/swagger/{documentName}/swagger.json");
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/survey/swagger/v{version}/swagger.json", $"user microservice V{version}");
                options.RoutePrefix = "survey"; // Set Swagger UI at apps root
            });

            var rewriteOptions = new RewriteOptions()
                .AddRedirect("/survey", "/Survey");
            app.UseRewriter(rewriteOptions);
        }
    }
}
