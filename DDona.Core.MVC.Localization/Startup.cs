using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDona.Core.MVC.Localization
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opts => opts.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(opts => opts.ResourcesPath = "Resources");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            IList<CultureInfo> cultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR")
            };

            var requestLocalizationOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            };

            app.UseRequestLocalization(requestLocalizationOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
