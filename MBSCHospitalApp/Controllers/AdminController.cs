using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models.Repositories;

namespace MBSCHospitalApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IAppointmentRepository _appointmentRepo;

        public AdminController(IDoctorRepository doctorRepo, IAppointmentRepository appointmentRepo)
        {
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
        }

        public IActionResult AdminDashboard()
        {
            var doctors = _doctorRepo.GetAllDoctors();
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

            _appointmentRepo.AddAppointment(appointment);
            return RedirectToAction("AdminDashboard");
        }
    }
}
