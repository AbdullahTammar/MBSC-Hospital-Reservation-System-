using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MBSCHospitalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult SelectUser(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
                return RedirectToAction("Index");

            if (user.IsAdmin)
                return RedirectToAction("AdminDashboard", "Admin");
            else
                return RedirectToAction("DoctorList", "Patient");
        }
    }
}
