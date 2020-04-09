using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AcaiApp.Domain.Entities;
using AcaiApp.Data.Context;
using AcaiApp.Services.Interfaces;
using AcaiApp.Services.Services;
using AcaiApp.Data.Interfaces;
using AcaiApp.Data.Repositories;

namespace AcaiApp
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
            services.AddDbContext<AcaiContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), builder =>
                builder.MigrationsAssembly("AcaiApp")));

            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IAdicionalService, AdicionalService>();
            services.AddScoped<ICalculosService, CalculosService>();
            services.AddScoped<IPedidoAdicionalService, PedidoAdicionalService>();

            services.AddScoped<IAdicionalRepository, AdicionalRepository>();
            services.AddScoped<IPedidoAdicionalRepository, PedidoAdicionalRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
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
