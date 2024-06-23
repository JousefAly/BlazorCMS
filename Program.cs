using AuctionTypesCMS.Components;
using AuctionTypesCMS.Repositories;
using AuctionTypesCMS.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
namespace AuctionTypesCMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CMSContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<IAuctionTypesRepository, AuctionTypesRepository>();
            builder.Services.AddScoped<IAuctionTypesServices, AuctionTypesService>();
            builder.Services.AddScoped<ICachedAuctionTypesRepository, CachedAuctionTypesRepository>();
            builder.Services.AddMudServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapControllers();

            app.Run();
        }
    }
}
