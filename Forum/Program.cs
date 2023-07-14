using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // Register routes
        RegisterRoutes(app);

        app.Run();
    }

    private static void RegisterRoutes(IApplicationBuilder app)
    {
        var routeBuilder = new RouteBuilder(app);

        routeBuilder.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");

        routeBuilder.MapRoute(
            name: "Register",
            template: "Account/Register",
            defaults: new { controller = "Account", action = "Register" });

        var routes = routeBuilder.Build();
        app.UseRouter(routes);
    }
}