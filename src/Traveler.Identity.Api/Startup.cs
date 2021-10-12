using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Traveler.Identity.Api.Filters;
using Traveler.Identity.Application.CommandHandlers;
using Traveler.Identity.Infra.CrossCutting.IoC.Configurations;

namespace Traveler.Identity.Api
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
            services.AddApiVersioning();
            services.AddVersionedApiExplorer();
            services.AddSwaggerSetup();
            services.AddAutoMapper();
            services.AddDatabaseSetup();
            services.AddDependencyInjectionSetup(Configuration);
            services.AddMediatR(typeof(CommandHandler));
            services.AddScoped<GlobalExceptionFilterAttribute>();
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("*");
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });


            app.UseRouting();

            app.UseAuthorization();
            app.UseSwaggerSetup(provider);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}