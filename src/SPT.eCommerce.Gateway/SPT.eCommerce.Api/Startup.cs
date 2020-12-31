using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SPT.eCommerce.Api.EntityStore;
using SPT.eCommerce.Api.Service;

namespace SPT.eCommerce.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Startup

    {
        public static readonly string ApiName = typeof(Startup).Module.Name.Replace(".dll", "");
        private const string ApiDescription = "eCommerce Demo API for training";
        private const string ApiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(new ApplicationDbContext());

            services.AddTransient<IProductService, ProductService>();
            var hcBuilder = services.AddHealthChecks();
            
            RegisterDocumentationGenerator(services);

        }

        private void RegisterDocumentationGenerator(IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            // more info can be found https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion,
                    new OpenApiInfo
                    {
                        Version = ApiVersion,
                        Title = ApiName,
                        Description = ApiDescription
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureDocumentationGenerator(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        private static void ConfigureDocumentationGenerator(IApplicationBuilder app)
        {
            
            // Enable middle ware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" }
                    };
                });
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", ApiDescription);
                c.RoutePrefix = "docs"; // {api-url}/docs/ will open Swagger UI
            });
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
