using Microsoft.AspNetCore.Mvc;

namespace MBSCHospitalApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}