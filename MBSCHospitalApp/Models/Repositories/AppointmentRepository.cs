using MBSCHospitalApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MBSCHospitalApp.Models.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.User)
                .FirstOrDefault(a => a.Id == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void ReserveAppointment(int appointmentId, int userId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            if (appointment != null && appointment.UserId == null)
            {
                appointment.UserId = userId;
                _context.SaveChanges();
            }
        }
    }
}
