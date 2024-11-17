using DataAccessLayer;
using EntityModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

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
})
.AddEntityFrameworkStores<DatabaseContext>();//.AddDefaultTokenProviders();


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//            ValidAudience = builder.Configuration["JwtSettings:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
//        };
//    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Nobatdehi",
        Description = "Special Web Application For Generate and Manage Citizen Turns For Registered General Plans."
    });

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Please enter JWT with Bearer scheme (e.g., 'Bearer {token}')",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer"
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //            Scheme = "oauth2",
    //            Name = "Bearer",
    //            In = ParameterLocation.Header,
    //        },
    //        new List<string> { "Admin", "User" }
    //    }
    //});
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CostumIdentityUser>>();

    await EnsureRolesAsync(roleManager);
    await EnsureAdminUserAsync(userManager);


    //Console.WriteLine($"Admin Token: Bearer {adminToken}");

    //var tokenHandler = new JwtSecurityTokenHandler();
    //var tokenS = tokenHandler.ReadToken(adminToken) as JwtSecurityToken;
    //var roleClaim = tokenS?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
    //Console.WriteLine($"Role: {roleClaim}");
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Nobatdehi Web Application");
app.MapGet("/error", () => "Pleas Try Again With Currect Data!");

app.Run();


//string GenerateJwtToken(string username, string role)
//{
//    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TheBrownQuickFoxJumpIntoTheBlackHole712635!"));
//    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//    var claims = new[]
//    {
//        new Claim(ClaimTypes.Name, username),
//        new Claim(ClaimTypes.Role, role)
//    };

//    var token = new JwtSecurityToken(
//        issuer: "http://localhost:5000",
//        audience: "https://localhost:5001",
//        claims: claims,
//        expires: DateTime.Now.AddHours(1),
//        signingCredentials: credentials);

//    return new JwtSecurityTokenHandler().WriteToken(token);
//}


async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { "Admin", "User" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}


async Task EnsureAdminUserAsync(UserManager<CostumIdentityUser> userManager)
{
    var adminUser = await userManager.FindByNameAsync("Admin_com");
    if (adminUser == null)
    {
        adminUser = new CostumIdentityUser { UserName = "Admin_com", FirstName = "Amir", LastName = "Bakhtiyari", Status = true };
        await userManager.CreateAsync(adminUser, "aMir!2001");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }

    //return GenerateJwtToken(adminUser.UserName, "Admin");
}
