using MBSCHospitalApp.Models.Entities;

namespace MBSCHospitalApp.Models.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        void AddUser(User user);
    }
}
