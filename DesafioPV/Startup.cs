using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioPV.Infra;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate.Tool.hbm2ddl;

namespace DesafioPV
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
            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            IPersistenceConfigurer dbConfig = MySQLConfiguration.Standard.ConnectionString("Server=localhost;Port=3306;Database=desafiopv;Uid=sances;Pwd=laranjauva;");
            var _sessionFactory = Fluently.Configure()
                                      .Database(dbConfig)
                                      .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                                      .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                                      .BuildSessionFactory();

            //Creates database structure



            services.AddScoped(factory =>
            {
                return _sessionFactory.OpenSession();
            });

           // services.AddScoped(factory =>
           //{
           //    return ConnectionNH.StartSession();
           //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
