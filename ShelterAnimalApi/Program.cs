using DataAccess.Models;
using System.Reflection;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DataAccess.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;

namespace ShelterAnimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AnimalShelterContext>(
             options => options.UseSqlServer(
                "Server=LAPTOP-886FNGF4;Database=AnimalShelter;Trusted_Connection=True;TrustServerCertificate=True;"));




            // Register repositories
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
