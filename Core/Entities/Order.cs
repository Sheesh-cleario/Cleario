namespace Core.Entities
{
	public class Order
	{
		public int OrderId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerNumber { get; set; }
		public string CustomerEmail { get; set; }
		public OrderObjectDetails OrderObjectDetails { get; set; }
		public List<CleaningTask> CleaningTasks { get; set; }
		public UserMessage RelatedData { get; set; }
		public OrderDescription OrderDescription { get; set; }
		public int Price { get; set; }
	}
}