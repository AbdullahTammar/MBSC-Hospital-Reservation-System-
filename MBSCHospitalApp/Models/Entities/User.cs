namespace MBSCHospitalApp.Models.Entities 
{
	public class User 
	{
		public int Id { get; set;}
		public string UserName { get; set;}
		public bool IsAdmin { get; set;}

		public ICollection<Appointment> Appointments { get; set;}
	}
}