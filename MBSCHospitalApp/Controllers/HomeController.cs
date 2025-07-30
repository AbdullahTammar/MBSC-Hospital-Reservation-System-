using Microsoft.AspNetCore.Mvc;
using MBSCHospitalApp.Models.Repositories;
using Microsoft.AspNetCore.Http;

namespace MBSCHospitalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepo;

        public HomeController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            var users = _userRepo.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult SelectUser(int userId)
        {
            var user = _userRepo.GetUserById(userId);

            if (user == null)
                return RedirectToAction("Index");

            HttpContext.Session.SetInt32("CurrentUserId", user.Id);

            if (user.IsAdmin)
                return RedirectToAction("AdminDashboard", "Admin");
            else
                return RedirectToAction("DoctorList", "Patient");
        }
    }
}
