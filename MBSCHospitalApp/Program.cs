using MBSCHospitalApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

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


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Users.Any())
    {
        context.Users.AddRange(
            new MBSCHospitalApp.Models.Entities.User { UserName = "Admin User", IsAdmin = true },
            new MBSCHospitalApp.Models.Entities.User { UserName = "Patient User 1", IsAdmin = false },
            new MBSCHospitalApp.Models.Entities.User { UserName = "Patient User 2", IsAdmin = false }
        );
        context.SaveChanges();
    }
}

app.Run();
