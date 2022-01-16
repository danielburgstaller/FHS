using FHS_Example.Data;
using FHS_Example.Model;
using FHS_Example.Service;
using FHS_Example.ViewModel;
using Microsoft.JSInterop;

namespace FHS_Example
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<ICDNJSService>(s => new CDNJSService("https://api.cdnjs.com"));

            services.AddTransient<ILibraryModel, LibraryModel>();

            services.AddTransient<ILibrariesViewModel, LibrariesViewModel>();
            services.AddSingleton<WeatherForecastService>();
        }

        private RequestLocalizationOptions GetLocalizationOptions()
        {
            var cultures = Configuration.GetSection("Cultures")
                .GetChildren()
                .ToDictionary(x => x.Key, x => x.Value);

            var supportedCultures = cultures.Keys.ToArray();
            var localizationOptions = new RequestLocalizationOptions()
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            return localizationOptions;
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRequestLocalization(GetLocalizationOptions());


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
