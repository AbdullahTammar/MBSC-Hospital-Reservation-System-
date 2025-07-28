namespace MBSCHospitalApp.Models.Entities 
{
	public class Appointment 
	{
		public int Id { get; set; }
		public string AppointmentTime { get; set; }

		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }

		public int? UserId { get; set; }
		public User User { get; set; }
	}
}