using AutoMapper;
using Library.Business.Contracts;
using Library.Business.Services;
using Library.Common.Providers;
using Library.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.API
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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            });

            this.RegisterData(services);
            services.AddAutoMapper();
            services.AddScoped<IMappingProvider, MappingProvider>();
            services.AddTransient<IAuthorsService, AuthorsService>();
            services.AddTransient<IBooksService, BooksService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LibraryDbContext libraryDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error occured. Please, try again later.");
                    });
                });
            }

            app.UseHttpsRedirection();
            libraryDbContext.EnsureSeedDataForContext();
            app.UseMvc();  
        }

        private void RegisterData(IServiceCollection services)
        {
            if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            }
            else
            {
                services.AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.BuildServiceProvider().GetService<LibraryDbContext>().Database.Migrate();
        }
    }
}
