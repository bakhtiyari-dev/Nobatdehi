using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddIdentity<CostumIdentityUser, IdentityRole>(c =>
{
    c.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_";
    c.Password.RequireDigit = true;
    c.Password.RequireLowercase = true;
    c.Password.RequireUppercase = true;
    c.Password.RequireNonAlphanumeric = true;

}).AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Nobatdehi",
            Description = "Special Web Application For Generate and Manage Citizen Turns For Registered General Plans."
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.MapGet("/", () => "Nobatdehi Web Application");

app.Run();
