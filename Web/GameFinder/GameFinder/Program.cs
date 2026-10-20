using Microsoft.EntityFrameworkCore;
namespace GameFinder
{
    using GameFinder.Data;
    using GameFinder.Services;
    using GameFinder.Services.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;


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
            builder.Services.AddScoped<IUserFavouriteService, UserFavouriteService>();

            builder.Services.AddDefaultIdentity<IdentityUser>(opt =>
            {
                ConfigureIdentityOptions(opt, builder.Configuration);
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GameFinderDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

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
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentityOptions(IdentityOptions opt, ConfigurationManager configuration)
        {
            opt.Password.RequireDigit = configuration.GetValue<bool>("Identity:Password:RequireDigit");
            opt.Password.RequireLowercase = configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            opt.Password.RequireUppercase = configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            opt.Password.RequiredUniqueChars = configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");
            opt.Password.RequiredLength = configuration.GetValue<int>("Identity:Password:RequiredLength");
            opt.Password.RequireNonAlphanumeric = configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

            opt.SignIn.RequireConfirmedAccount = configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            opt.User.RequireUniqueEmail = configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
