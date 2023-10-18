public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Set up configuration from appsettings.json
        builder.Configuration.AddJsonFile("appsettings.json");

        var app = builder.Build();

        app.UseRouting();

        // Register and configure your database context here

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.Run();
    }
}