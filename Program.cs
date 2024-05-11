
using QualaBackEndTest.Application;
using QualaBackEndTest.Application.Services;
using QualaBackEndTest.Core.Entities;
using QualaBackEndTest.Core.Repositories;
using QualaBackEndTest.Infrastructure;

namespace QualaBackEndTest
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

            builder.Services.AddScoped<ISucursalService, SucursalService>();
            builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();

            builder.Services.AddSqlServer<QualaBackEndBdContext>(builder.Configuration.GetConnectionString("Connection"));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost4200",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("AllowLocalhost4200");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}