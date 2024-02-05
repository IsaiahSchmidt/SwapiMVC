public class Startup 
{
    public IConfiguration configRoot {
        get;
    }
    public Startup(IConfiguration configuration) {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services) {
        services.AddHttpClient("swapi", client =>
        {
            client.BaseAddress = new Uri("https://swapi.dev/api/");
        });
        services.AddControllersWithViews();
        services.AddRazorPages();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env) {
        if(!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}