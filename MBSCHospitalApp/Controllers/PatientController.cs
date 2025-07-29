using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MBSCHospitalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult DoctorList()
        {
            var doctors = _context.Doctors
                .Include(d => d.Appointments)
                .ToList();

            return View(doctors);
        }

        [HttpPost]
        public IActionResult ReserveAppointment(int appointmentId, int userId)
        {
            var appointment = _context.Appointments.Find(appointmentId);

            if (appointment == null || appointment.UserId != null)
            {
                return RedirectToAction("DoctorList");
            }

            appointment.UserId = userId;
            _context.SaveChanges();

            return RedirectToAction("DoctorList");
        }
    }
}
