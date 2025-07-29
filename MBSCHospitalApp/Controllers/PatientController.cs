using Microsoft.AspNetCore.Mvc;

namespace MBSCHospitalApp.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult DoctorList()
        {
            return View();
        }
    }
}