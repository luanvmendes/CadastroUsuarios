using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using UsersService.App.Adapter;
using UsersService.App.Application;
using UsersService.Domain.Model;
using UsersService.Infra.Context;
using UsersService.Infra.Repository;
using UsersService.Infra.UnitOfWork;

namespace UsersService.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string AllowSpecificOrigins { get { return "CorsOrigins"; } }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(Configuration.GetSection("CorsOrigins").Value)
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
            });

            services.AddControllersWithViews()
                .AddControllersAsServices()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Usuarios",
                    Version = "v1"
                });
            });

            services.AddDbContext<UsersContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Users"));
            });

            services.AddMediatR(this.GetType());
            services.AddAutoMapper(this.GetType());

            services.AddScoped<IUserAdapter, UserAdapter>();
            services.AddScoped<IUserApplication, UserApplication>();

            services.AddScoped<IRepository<Usuarios>, Repository<Usuarios>>();

            services.AddScoped<IUsersUnitOfWork>(sp => new UsersUnitOfWork(sp.GetRequiredService<UsersContext>()
                , ((Type type, IRepository repository))(typeof(Usuarios), sp.GetRequiredService<IRepository<Usuarios>>())));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);
            app.UseEndpoints(ep =>
            {
                ep.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API v1");
            });
        }
    }
}
