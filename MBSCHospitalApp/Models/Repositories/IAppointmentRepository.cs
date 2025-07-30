using MBSCHospitalApp.Models.Entities;

namespace MBSCHospitalApp.Models.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment? GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void ReserveAppointment(int appointmentId, int userId);
    }
}
