using BookShop.Data;
using BookShop.Models.Entities;
using BookShop.Repositories;
using BookShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
