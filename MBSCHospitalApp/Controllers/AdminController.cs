using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MBSCHospitalApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminDashboard()
        {
            var doctors = _context.Doctors
                .Include(d => d.Appointments)
                .ToList();

            return View(doctors);
        }

        [HttpPost]
        public IActionResult AddAppointment(int doctorId, string appointmentTime)
        {
            var appointment = new MBSCHospitalApp.Models.Entities.Appointment
            {
                DoctorId = doctorId,
                AppointmentTime = appointmentTime
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("AdminDashboard");
        }
    }
}
