using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Theatres.BLL.Contracts;
using Theatres.BLL.Implementation;
using Theatres.DataAccess.Context;
using Theatres.DataAccess.Contracts;
using Theatres.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Theatres.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(ITheatreCreateService),typeof(TheatreCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITheatreGetService),typeof(TheatreGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITheatreUpdateService),typeof(TheatreUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPerfomanceCreateService),typeof(PerfomanceCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPerfomanceGetService),typeof(PerfomanceGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPerfomanceUpdateService),typeof(PerfomanceUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScheduleCreateService),typeof(ScheduleCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScheduleGetService),typeof(ScheduleGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IScheduleUpdateService),typeof(ScheduleUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ITheatreDataAccess), typeof(TheatreDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPerfomanceDataAccess), typeof(PerfomanceDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IScheduleDataAccess), typeof(ScheduleDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<TheatreContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Theatres")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TheatreContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}