using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReadBundleLibrary;
using ReadBundleLibrary.Helpers.BundleFetcher;
using System.Text.Json;

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
        services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    //options.SerializerSettings.Formatting = Formatting.Indented; 
                });
                

        services.AddSingleton<BundleLibrary>();

        //We want to use the ACR fetcher to get the bundle
        services.AddSingleton<IBundleFetcher, ACRBundleFetcher>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
            endpoints.MapControllers()
        );
    
    }
}
