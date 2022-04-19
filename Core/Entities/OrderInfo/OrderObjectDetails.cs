namespace Core.Entities
{
	public class OrderObjectDetails
	{
		public int OrderObjectDetailsId { get; set; }
		public string ObjectAddres{ get; set; }
		public CleaningType CleaningType { get; set; }
		public int CleaningArea { get; set; }
		public DateTime CleaningDate { get; set; }
	}

	public enum CleaningType
	{
		A,
		B,
		C
	}
}