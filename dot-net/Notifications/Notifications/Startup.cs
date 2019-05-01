using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.Common;
using Notifications.Common.Helpers;
using Notifications.Common.Interfaces;
using Notifications.DataAccess;
using Notifications.DataAccess.Access;
using Notifications.Middlewares;
using Notifications.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Notifications
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.Configure<Config>(Configuration);
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"});
      });

      services.AddDbContext<NotificationsDbContext>(options =>
        options.UseSqlServer(Configuration["ConnectionString"]));

      services.AddTransient<INotificationsAccess, NotificationsAccess>();
      services.AddTransient<INotificationsService, NotificationsService>();
      services.AddSingleton(ConfigureMappings.GetMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
      }
      else
      {
        app.UseHsts();
      }
      
      app.UseMiddleware<GlobalExceptionHandler>();

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}