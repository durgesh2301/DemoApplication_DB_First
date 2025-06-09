
using QuickStartDALLayer;
using QuickStartDALLayer.Models;

namespace Minimal_API_SL_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<QuickStartDbContext>();
            builder.Services.AddTransient<QuickStartRepository>(
                c => new QuickStartRepository(c.GetRequiredService<QuickStartDbContext>()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/GetProducts",() =>
            {
                var products = app.Services.GetRequiredService<QuickStartRepository>().GetAllProducts();
            return products;
            }).WithName("GetAllProducts").WithOpenApi();

            app.Run();
        }
    }
}
