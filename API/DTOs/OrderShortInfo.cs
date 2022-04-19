namespace API.DTOs
{
	public class OrderShortInfo
	{
		public int OrderId { get; set; }
		public string CustomerNumber { get; set; }
		public string ObjectAddress { get; set; }
		public DateTime Time { get; set; }
		public string Status { get; set; }
		public int Price { get; set; }
	}
}
