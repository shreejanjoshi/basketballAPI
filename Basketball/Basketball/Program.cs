
using Basketball.Services;

namespace Basketball
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // for migartions
            //builder.Services.AddDbContext<DataDbContext>(options =>
            //{
            //    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //    var serverVersion = ServerVersion.AutoDetect(connectionString);

            //    options.UseMySql(connectionString, serverVersion);
            //});

            builder.Services.AddSingleton<IBasketballClubService, BasketballClubService>();
            builder.Services.AddSingleton<ICityService, CityService>();
            builder.Services.AddSingleton<ICountryService, CountryService>();

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
