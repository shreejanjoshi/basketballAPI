
using Basketball.Data;
using Basketball.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Basketball
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // voor sql connection
            builder.Services.AddDbContext<BasketballDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                var serverVersion = ServerVersion.AutoDetect(connectionString);

                options.UseMySql(connectionString, serverVersion);
            });

            builder.Services.AddSingleton<IBasketballClubService, BasketballClubService>();
            builder.Services.AddSingleton<ICityService, CityService>();
            builder.Services.AddSingleton<ICountryService, CountryService>();

            // Configure DI to switch between in-memory and database implementations
            if (builder.Configuration["UseInMemory"] == "true")
            {
                builder.Services.AddSingleton<IBasketballClubService, BasketballClubService>();
                builder.Services.AddSingleton<ICityService, CityService>();
                builder.Services.AddSingleton<ICountryService, CountryService>();
            }
            else
            {
                builder.Services.AddScoped<IBasketballClubService, BasketballClubDatabaseService>();
                builder.Services.AddScoped<ICityService, CityDatabaseService>();
                builder.Services.AddScoped<ICountryService, CountryDatabaseService>();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
