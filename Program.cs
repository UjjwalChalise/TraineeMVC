using Microsoft.EntityFrameworkCore;
using TraineeMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext


builder.Services.AddDbContext<TraineeDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Register Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
)
.WithStaticAssets();

app.Run();