using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Services;
using Services.Middleware;

namespace MovieAPI
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
            services.AddScoped<MovieSeeder>();
            services.AddAutoMapper(typeof(Services.AssemblyReference).Assembly);

          //services.AddControllers()
            //    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddPersistenceService();
            services.AddService();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddDbContext<MovieDBContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("MovieDbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MovieSeeder seeder)
        {
            seeder.Seed();  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieAPI v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
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
