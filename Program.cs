using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using FinalPrac.Models;
using FinalPrac.Data;
var builder = WebApplication.CreateBuilder(args);






builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBContext")));

builder.Services.AddEndpointsApiExplorer(); //Ved ikke, men virker til vores logout

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddDefaultUI()
.AddEntityFrameworkStores<DBContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddDbContext<DBContext>(options =>
// options.UseSqlite("DBContext"));




var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     SeedData.Initialize(services);
// }

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
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"); //{id?}

app.Run();
