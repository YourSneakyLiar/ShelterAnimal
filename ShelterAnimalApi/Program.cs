using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using DataAccess.Wrapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Wrapper;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ShelterAnimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AnimalShelterContext>(options =>
                  options.UseSqlServer(builder.Configuration["ConnectionString"]));




            // Register repositories
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdopterService, AdopterService>(); // ������ ��� ������ � �������������
            builder.Services.AddScoped<IAdoptionService, AdoptionService>(); // ������ ��� ������ � �������������
            builder.Services.AddScoped<IAnimalService, AnimalService>(); // ������ ��� ������ � ���������
            builder.Services.AddScoped<IAuditLogService, AuditLogService>(); // ������ ��� ������ � �������� ������
            builder.Services.AddScoped<IBreedService, BreedService>(); // ������ ��� ������ � ��������
            builder.Services.AddScoped<IDonationService, DonationService>(); // ������ ��� ������ � ���������������
            builder.Services.AddScoped<IEventService, EventService>(); // ������ ��� ������ � �������������
            builder.Services.AddScoped<IEventAttendanceService, EventAttendanceService>(); // ������ ��� ������ � ����������� �����������
            builder.Services.AddScoped<IExpenseService, ExpenseService>(); // ������ ��� ������ � ���������
            builder.Services.AddScoped<IIncomeService, IncomeService>(); // ������ ��� ������ � ��������
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>(); // ������ ��� ������ � ������������ ��������
            builder.Services.AddScoped<IRoleService, RoleService>(); // ������ ��� ������ � ������
            builder.Services.AddScoped<ISpeciesService, SpeciesService>(); // ������ ��� ������ � ������ ��������
            builder.Services.AddScoped<IStaffService, StaffService>(); // ������ ��� ������ � ������������
            builder.Services.AddScoped<ISupplyService, SupplyService>(); // ������ ��� ������ � ����������
            builder.Services.AddScoped<ISupplyOrderService, SupplyOrderService>(); // ������ ��� ������ � �������� ��������
            builder.Services.AddScoped<IUserRoleService, UserRoleService>(); // ������ ��� ������ � ������ �������������
            builder.Services.AddScoped<IVaccinationService, VaccinationService>(); // ������ ��� ������ � ������������
            builder.Services.AddScoped<IVolunteerService, VolunteerService>(); // ������ ��� ������ � �����������


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API ������ ��� ��������",
                    Description = "����������� ��� ������ � �����������",
                    Contact = new OpenApiContact
                    {
                        Name = "���� �������",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "���� ��������",
                        Url = new Uri("https://example.com/license")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AnimalShelterContext>();
                context.Database.Migrate(); // ��������� �������� �������������
            }

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
            
            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseCors(builder => builder.WithOrigins(new[] { "https://shelteranimalapi.onrender.com", })
                                                   .AllowAnyHeader()
                                                   .AllowAnyMethod()
                                                   .AllowAnyOrigin());


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
