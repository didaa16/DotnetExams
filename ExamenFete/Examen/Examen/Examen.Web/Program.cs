using System.Drawing;
using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Infrastructure;
using Exmaen.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IService<Invitation>, Service<Invitation>>();
builder.Services.AddScoped<IService<Invite>, Service<Invite>>();
builder.Services.AddScoped<IService<Fete>, Service<Fete>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DbContext, ExamContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
