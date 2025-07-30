using MBSCHospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using MBSCHospitalApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
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

    if (!context.Doctors.Any())
    {
        var doctor1 = new MBSCHospitalApp.Models.Entities.Doctor { Name = "Dr. Rami", Specialty = "Cardiology" };
        var doctor2 = new MBSCHospitalApp.Models.Entities.Doctor { Name = "Dr. Khaled", Specialty = "Dermatology" };

        context.Doctors.AddRange(doctor1, doctor2);
        context.SaveChanges();

        context.Appointments.AddRange(
            new MBSCHospitalApp.Models.Entities.Appointment { DoctorId = doctor1.Id, AppointmentTime = "10:00 AM" },
            new MBSCHospitalApp.Models.Entities.Appointment { DoctorId = doctor1.Id, AppointmentTime = "11:00 AM" },
            new MBSCHospitalApp.Models.Entities.Appointment { DoctorId = doctor2.Id, AppointmentTime = "2:00 PM" }
        );
        context.SaveChanges();
    }
}

app.Run();
