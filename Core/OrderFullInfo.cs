using Microsoft.AspNetCore.Http;

namespace Core
{
	public class OrderFullInfo
	{
		public string CustomerName { get; set; }
		public string CustomerNumber { get; set; }
		public string CustomerEmail { get; set; }
		public string ObjectAddres { get; set; }
		public int CleaningType { get; set; }
		public int CleaningArea { get; set; }
		public DateTime CleaningDate { get; set; }
		public int Price { get; set; }
		public List<string> Tasks { get; set; }
		public string Comment { get; set; }
		public List<IFormFile> Files { get; set; }
	}

}
