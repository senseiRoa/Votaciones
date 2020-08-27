using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Demokratianweb.Data;
using Demokratianweb.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Demokratianweb.Data.Infraestructure;
using Demokratianweb.Service;
using System;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Demokratianweb.HubRT;

namespace Demokratianweb
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
            var cs = Configuration.GetConnectionString("DefaultConnection");
            //Console.WriteLine("mi cadena de conexion es :" + cs);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(cs));
           
            // repository
            services.AddScoped<CandidatoRepository>();
            services.AddScoped<ControlVotoVotanteRepository>();
            services.AddScoped<RondaCandidatoRepository>();
            services.AddScoped<RondaVotacionRepository>();
            services.AddScoped<VotacionCandidatoRepository>();
            services.AddScoped<VotacionRepository>();
            services.AddScoped<VotacionVotanteRepository>();
            services.AddScoped<VotanteRepository>();
            services.AddScoped<VotoRondaRepository>();
            // service
            services.AddScoped<RondaVotacionService>();
            services.AddScoped<VotacionService>();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication()
                .AddIdentityServerJwt()
                
                ;
            services.AddControllersWithViews();

            //signalR
            services.AddSignalR();
            //mail 
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, CustomEmailSender>();
            //services.AddTransient<IProfileService, ProfileService>();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IHostingEnvironment env = serviceProvider.GetService<IHostingEnvironment>();
            if (env.IsProduction())
            {

                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });

            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (env.IsProduction())
            {
                app.UseSpaStaticFiles();
                app.UseStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapHub<NotifyHub>("/notify");
                
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
