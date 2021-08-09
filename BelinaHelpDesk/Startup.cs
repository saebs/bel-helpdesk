using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BelinaHelpDesk.Areas.Identity;
using BelinaHelpDesk.Data;
using Syncfusion.Blazor;

namespace BelinaHelpDesk
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
            services.AddDbContext<BelinaHelpDeskContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BelinaHelpDeskContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services
                .AddScoped<AuthenticationStateProvider,
                    RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register Syncfusion license
            Syncfusion
                .Licensing
                .SyncfusionLicenseProvider
                .RegisterLicense("NDg1MjA5QDMxMzkyZTMyMmUzMFZSZDI3QTdFTWVsdU1aS2pXYVV3cGhaUUFjZ2YvVlNEWEhJSE8rUXNGeGc9;NDg1MjEwQDMxMzkyZTMyMmUzMGkrN2NuSnhzVUF6V2tHZ1F6OTJZU2Q2czMvZHFCUGdTMnpMWXhhcW1nWmM9;NDg1MjExQDMxMzkyZTMyMmUzMEUyQlhuR3lyOEtHeC8xTVIzeEJLeGFhdzJmeG9rRFJKdVQ5U1BCblJzbnc9;NDg1MjEyQDMxMzkyZTMyMmUzMFIrNzlscDYrd2IxRDlZQ1Uray9TN1gwTmNtMXZvMWIzZWJ2MmNieHpsYmM9;NDg1MjEzQDMxMzkyZTMyMmUzMGlnbXNLRDV3SGpvU2FuWU9aeDJWYjBXbHBNRzcwWGZxOXAwemxwVHVHcm89;NDg1MjE0QDMxMzkyZTMyMmUzMGxEVEE5ajNZQ25pa1ZueUQ1RzBRcndORFlxMHBMd3pxSk5Md1B1VXZXTEE9;NDg1MjE1QDMxMzkyZTMyMmUzME03RHBKOU1QeUwybWwxcTd0WVozdVVvZkJWK0R0TXNQa3FQM2FxMytua1k9;NDg1MjE2QDMxMzkyZTMyMmUzMG9ZbjJaemlJNkttWjJPQlFIWisxRXYyR0loZTYySjE5NDhnbHNlb1hZd2c9;NDg1MjE3QDMxMzkyZTMyMmUzMElXRWZuNnJpSVJPMmFXN3BtQkJZK0FjVnNzK1hJd3dDMG44TjBvQUxJdDg9;NDg1MjE4QDMxMzkyZTMyMmUzMGJsaVQ3Z1VTN0haSVJyYlV0ZEoxQUsycWMzbjQ1SUZJa25JN0Z6SWJsV1U9");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}