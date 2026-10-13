namespace GameFinder
{
    using GameFinder.Data;
    using GameFinder.Services;
    using GameFinder.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using GameFinder.Services;
    using GameFinder.Services.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<GameFinderDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddScoped<IGenreService, GenreService>();

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
