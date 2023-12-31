using FlightManagement.Server.Data;
using FlightManagement.Server.Extensions;
using FlightManagement.Server.LoggerService;

using Microsoft.EntityFrameworkCore;

using NLog;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();


    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddServerSideServices();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    var logger = app.Services.GetRequiredService<ILoggerManager>();
    app.ConfigureExceptionHandler(logger);


    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();


    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();


}

