using DAL;
using Microsoft.AspNetCore.Identity;

// Add a reference to your DAL project.

namespace Web;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddDbContext<ApplicationDbContext>(options =>
        //     options.UseSqlServer(Configuration.GetConnectionString("connectionDb")));
        
        services.AddIdentity<DAL.Models.ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // Add other services
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
    {
        // Create roles
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole
            {
                Name = "Admin"
            };
            roleManager.CreateAsync(role).Wait();
        }
    
        if (!roleManager.RoleExistsAsync("ProjectManager").Result)
        {
            var role = new IdentityRole
            {
                Name = "ProjectManager"
            };
            roleManager.CreateAsync(role).Wait();
        }
        
        // Add more roles as needed

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}