using MBSCHospitalApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MBSCHospitalApp.Models.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.User)
                .ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.User)
                .FirstOrDefault(d => d.Id == id);
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
    }
}
