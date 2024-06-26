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
using Microsoft.AspNetCore.Identity.UI.Services;
using LeaveManagmentWebApp.Services;
using Serilog;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// enable the roles,or the identityrole know we gonna add roles
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25 , "no-reply@leavemanagment.com"));


// open a query close a query when is done 
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // give a new connection when it called but when is finished it closed down
builder.Services.AddScoped<iLeaveTypeRepositoty, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped<ILeaveRequestsRepository, LeaveRequestsRepository>();
// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((ctx, lc) =>
lc.WriteTo.Console()
.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
