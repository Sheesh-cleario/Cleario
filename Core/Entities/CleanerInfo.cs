namespace Core.Entities
{
	public class CleanerInfo
	{
		public int CleanerInfoId { get; set; }
		public int CleanerId { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public int Rating { get; set; }
	}
}