
using ApiDay01.Entity;
using ApiDay01.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiDay01
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

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();





            /////////////////
            builder.Services.AddDbContext<ApplicationDbContext>(opt=>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con"));
            });

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                });
            }
                );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
