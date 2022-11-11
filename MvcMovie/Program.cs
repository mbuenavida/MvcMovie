using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Services.Repository;

namespace MvcMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registro del Context --> Sustituido por DesignTimeContextFactory.cs
            //builder.Services.AddDbContext<MvcMovieContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext") ?? 
            //    throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Service for repositories Interfaces
            builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
         

            var app = builder.Build();

            // Seed the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }
    }
}