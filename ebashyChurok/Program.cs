using AuthDomain;
using AuthDomain.Queries;
using AuthDomain.Queries.Object;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("sql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(row => row.UseSqlServer(path));
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IQueryService<EntryDTO, User?>, AuntificationQueryService>();
builder.Services.AddScoped<IQueryService<User, ClaimsPrincipal>, CreatePrincipalQueryService>();
builder.Services.AddScoped<IQueryService<RegistrationDTO, User?>, RegistrationUserQueryService>();

builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/AccessDenied";
                });
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Autorization", police => 
    { 
        police.RequireClaim("role", "User", "Admin", "GoldBoy");
    });
});


var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();