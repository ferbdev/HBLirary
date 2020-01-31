using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Client.Domain.Models;
using Web.Client.Domain.Services;
using Web.Client.Infra.Services;

namespace Web.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Web.Client.Infra.HBLibraryService.BookObject, Web.Client.Domain.Models.BookObject>()
                .ForMember(dest => dest.BookReleaseDate, m => m.MapFrom(a => a.BookReleaseDate.Value.DateTime));
                config.CreateMap<Web.Client.Infra.HBLibraryService.DefaultMethodResultObject, Web.Client.Domain.Models.DefaultMethodResultObject>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSingleton(new Configs(_configuration.GetConnectionString("ApiUrl")));

            services.AddTransient<ILibraryService, LibraryService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
