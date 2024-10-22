using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Vinoteca.Controllers;
using Vinoteca.Data;
using Vinoteca.Entities;
using Vinoteca.Repository;
using Vinoteca.Repository.interfaces;
using Vinoteca.Services;
using Vinoteca.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VinotecaContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:VinotecaAPIDBConnectionString"]));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWineService, WineService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWineRepository, WineRepository>();
builder.Services.AddScoped<UserRepository>();


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
