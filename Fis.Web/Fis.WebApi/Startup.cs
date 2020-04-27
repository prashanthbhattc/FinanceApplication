
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Fis.Repository.Context;

namespace Fis.WebApi
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
          var f=  Configuration.GetSection("Authority").ToString();
            services.AddDbContext<FisDataContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DataContext")));
            var builder = services.AddIdentityServer().AddDeveloperSigningCredential()
                                  .AddInMemoryApiResources(Config.Apis)
                                  .AddInMemoryClients(Config.Clients);
           services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = Constants.AuthorityUrl;
              // options.Authority = Configuration.GetSection("Authority").ToString();
               options.RequireHttpsMetadata = false;

               options.Audience = "api1";
           });
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
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
