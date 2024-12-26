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
            builder.Services.AddScoped<IAdopterService, AdopterService>(); // Сервис для работы с усыновителями
            builder.Services.AddScoped<IAdoptionService, AdoptionService>(); // Сервис для работы с усыновлениями
            builder.Services.AddScoped<IAnimalService, AnimalService>(); // Сервис для работы с животными
            builder.Services.AddScoped<IAuditLogService, AuditLogService>(); // Сервис для работы с записями аудита
            builder.Services.AddScoped<IBreedService, BreedService>(); // Сервис для работы с породами
            builder.Services.AddScoped<IDonationService, DonationService>(); // Сервис для работы с пожертвованиями
            builder.Services.AddScoped<IEventService, EventService>(); // Сервис для работы с мероприятиями
            builder.Services.AddScoped<IEventAttendanceService, EventAttendanceService>(); // Сервис для работы с посещениями мероприятий
            builder.Services.AddScoped<IExpenseService, ExpenseService>(); // Сервис для работы с расходами
            builder.Services.AddScoped<IIncomeService, IncomeService>(); // Сервис для работы с доходами
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>(); // Сервис для работы с медицинскими записями
            builder.Services.AddScoped<IRoleService, RoleService>(); // Сервис для работы с ролями
            builder.Services.AddScoped<ISpeciesService, SpeciesService>(); // Сервис для работы с видами животных
            builder.Services.AddScoped<IStaffService, StaffService>(); // Сервис для работы с сотрудниками
            builder.Services.AddScoped<ISupplyService, SupplyService>(); // Сервис для работы с поставками
            builder.Services.AddScoped<ISupplyOrderService, SupplyOrderService>(); // Сервис для работы с заказами поставок
            builder.Services.AddScoped<IUserRoleService, UserRoleService>(); // Сервис для работы с ролями пользователей
            builder.Services.AddScoped<IVaccinationService, VaccinationService>(); // Сервис для работы с вакцинациями
            builder.Services.AddScoped<IVolunteerService, VolunteerService>(); // Сервис для работы с волонтерами


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Приюта для животных",
                    Description = "Контроллеры для работы с приложением",
                    Contact = new OpenApiContact
                    {
                        Name = "Типа контакт",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Типа лицензия",
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
                context.Database.Migrate(); // Применяем миграции автоматически
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
