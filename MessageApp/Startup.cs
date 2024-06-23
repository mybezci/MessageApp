using MessageApp.Business;
using MessageApp.Hubs;

namespace MessageApp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options => options.AddDefaultPolicy(policy => 
            policy.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed(origin => true)
            ));
        services.AddTransient<MyBusiness>();
        services.AddSignalR();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors();
        
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<MyHub>("/myhub");
            endpoints.MapControllers();
            
        });
    }
    
}