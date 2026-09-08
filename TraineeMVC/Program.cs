using Microsoft.EntityFrameworkCore;
using TraineeMVC.Data;
using TraineeMVC.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<PasswordService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
// Microsoft.AspNetCore.Identity.UI
// microsoft.aspnetcore.identity.entityframeworkcore
// using TraineeMVC.Models;
// using Microsoft.EntityFrameworkCore;
//
// var builder = WebApplication.CreateBuilder(args);
//
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//
// builder.Services.AddDbContext<TraineeDBContext>(options =>
//     options.UseSqlServer(
//         connectionString
//     )
// );
//
// builder.Services.AddControllersWithViews();
//
// var app = builder.Build();
//
// app.UseHttpsRedirection();
// app.UseStaticFiles();
//
// app.UseRouting();
// app.UseAuthorization();
//
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}"
// );
//
// app.Run();