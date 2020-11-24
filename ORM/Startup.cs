using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ORM.Application.App;
using ORM.Application.App.Interface;
using ORM.Domain.Interface;
using ORM.Infrastructure.Repository;

namespace ORM
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
            services.AddScoped<IStudentApplication, StudentApplication>();
            services.AddScoped<IClassesApplication, ClassesApplication>();
            services.AddScoped<IDisciplineApplication, DisciplineApplication>();
            services.AddScoped<ICoordinatorApplication, CoordinatorApplication>();

            services.AddSingleton<IClassesRepository, ClassesRepository>();
            services.AddSingleton<IStudentRepository, StudentRepository>();
            services.AddSingleton<ICoordinatorRepository, CoordinatorRepository>();
            services.AddSingleton<IDisciplineRepository, DisciplineRepository>();
            services.AddControllers();
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
        }
    }
}
