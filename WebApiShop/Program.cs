using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<Repository.Models.UsersContext>
    (option => option.UseSqlServer("Data Source=LAPTOP-E7T8VC4N;Initial Catalog=AddNetExemple;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
