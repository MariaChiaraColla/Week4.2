using GestioneOrdini.BusinessLayer;
using GestioneOrdini.EF;
using GestioneOrdini.EF.EFRepository;
using GestioneOrdini.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestioneOrdini.RestApp
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
            //collego il DB
            services.AddDbContext<GestioneOrdiniContext>(
                options => options.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; Initial Catalog = OrderManagement; Server = .\SQLEXPRESS")
                );
            //collego i veri repository
            services.AddTransient<IRepositoryClient, RepositoryClientEF>();
            services.AddTransient<IRepositoryOrder, RepositoryOrderEF>();
            //collego il repository unico che ho creato, Business Layer
            services.AddTransient<IOrderBL, OrderBL>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestioneOrdini.RestApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestioneOrdini.RestApp v1"));
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
