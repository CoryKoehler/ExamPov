using System;
using System.Linq;
using Autofac;
using ExamPovApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExamPovApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services.AddMvc();
            services.AddMvcCore();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            var cosmosDbEventStoreUri = "mongodb://localhost:27017";
            var cosmosDbEventStoreDatabase = "Events";

            containerBuilder.RegisterAssemblyModules(
                AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("Exam", StringComparison.InvariantCulture)).ToArray());
            containerBuilder.AddEventFlow(cosmosDbEventStoreUri, cosmosDbEventStoreDatabase);
            containerBuilder.RegisterInstance(Configuration).As<IConfiguration>().SingleInstance();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            
            app.UseRouting();
            
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
