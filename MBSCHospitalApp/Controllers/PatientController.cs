using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models.Repositories;
using Microsoft.AspNetCore.Http;

namespace MBSCHospitalApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IAppointmentRepository _appointmentRepo;

        public PatientController(IDoctorRepository doctorRepo, IAppointmentRepository appointmentRepo)
        {
            _doctorRepo = doctorRepo;
            _appointmentRepo = appointmentRepo;
        }

        public IActionResult DoctorList()
        {
            var doctors = _doctorRepo.GetAllDoctors();
            return View(doctors);
        }

        [HttpPost]
        public IActionResult ReserveAppointment(int appointmentId)
        {
            var currentUserId = HttpContext.Session.GetInt32("CurrentUserId");
            if (currentUserId.HasValue)
            {
                _appointmentRepo.ReserveAppointment(appointmentId, currentUserId.Value);
            }
            return RedirectToAction("DoctorList");
        }
    }
}
