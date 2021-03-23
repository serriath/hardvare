using Hardvare.Services.Interfaces;
using Hardvare.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Hardvare.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(sui =>
                sui.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "The Hardvare Store API",
                    Description = "En enkel jernvarehandel fra Norges fjorder",
                    Contact = new OpenApiContact
                    {
                        Name = "William Francis",
                        Email = "dev.williamfrancis@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under OpenApiLicense",
                        Url = new Uri("https://example.com/license"),
                    }
                }));

            services.AddScoped<IAuthorRepository, AuthorRepository>();

            ////Autofac
            //var builder = new ContainerBuilder();
            //builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            //builder.Populate(services);


            //var container = builder.Build();
            //return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui =>
            {
                sui.SwaggerEndpoint("/swagger/v1/swagger.json", "The Hardvare Store");
            });
        }
    }
}
