using MBSCHospitalApp.Models.Entities;

namespace MBSCHospitalApp.Models.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor? GetDoctorById(int id);
        void AddDoctor(Doctor doctor);
    }
}
