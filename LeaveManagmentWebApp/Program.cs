using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using LeaveManagmentWebApp.Configuration;
using AutoMapper;
using LeaveManagmentWebApp.Contracts;
using LeaveManagmentWebApp.Repositories;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


// open a query close a query when is done 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // give a new connection when it called but when is finished it closed down
builder.Services.AddScoped<iLeaveTypeRepositoty, LeaveTypeRepository>();
// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

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
