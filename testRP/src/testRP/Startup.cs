using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadBundleLibrary;
using ReadBundleLibrary.Helpers.BundleFetcher;

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
                .AddNewtonsoftJson();

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

        //app.UseEndpoints(endpoints =>
        //{

        //    endpoints.Map("{*url}", async context =>
        //    {
        //        System.Console.WriteLine("Request details:");
        //        System.Console.WriteLine($"Method: {context.Request.Method}");
        //        System.Console.WriteLine($"Path: {context.Request.Path}");
        //        System.Console.WriteLine($"QueryString: {context.Request.QueryString}");
        //        System.Console.WriteLine("Headers:");
        //        foreach (var header in context.Request.Headers)
        //        {
        //            System.Console.WriteLine($"\t{header.Key}: {header.Value}");
        //        }
        //        context.Response.StatusCode = 200;
        //    });
        //});

    
    }
}
