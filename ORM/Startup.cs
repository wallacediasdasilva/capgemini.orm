using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
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

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
