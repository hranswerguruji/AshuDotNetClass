using EmployeeManagement.Data;
using EmployeeManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployeeManagementService, EmployeeManagementService>(); // This will create a new instance of EmployeeManagement for each HTTP request and reuse it within that request
//builder.Services.AddTransient<IEmployeeManagementService, EmployeeManagementService>(); // This will create a new instance every time it's requested
//builder.Services.AddSingleton<IEmployeeManagementService, EmployeeManagementService>(); // This will create a single instance of EmployeeManagement for the entire application and reuse it for all requests

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionEmployee")));



// Midelware for static assets

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
