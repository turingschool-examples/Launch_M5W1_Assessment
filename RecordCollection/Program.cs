using Microsoft.EntityFrameworkCore;
using RecordCollection.DataAccess;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("ErrorLogs/Logs.txt", outputTemplate: "{Timestamp:yyyy-MM-dd} [{Level:w3}] {Message:1j}{NewLine}{Exception}")
    .CreateLogger();


Log.Information("I like Turtles :)");









//
// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("RecordCollectionDb");

builder.Services.AddDbContext<RecordCollectionContext>(options => 
    options.UseNpgsql(connectionString)
    .UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
