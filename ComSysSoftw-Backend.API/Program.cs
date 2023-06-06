using ComSysSoftw_Backend.Infraestructure;
using ComSysSoftw_Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Context;
using ComSysSoftw_Backend.API.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInfraestructure, UserInfraestructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

//Conexion a sql

var connectionString = builder.Configuration.GetConnectionString("VetDB");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

builder.Services.AddDbContext<VetDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });



var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<VetDbContext>())
{
    context.Database.EnsureCreated();
}


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
