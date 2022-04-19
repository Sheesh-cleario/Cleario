namespace Core.Entities
{
	public class OrderDescription
	{
		public int OrderDescriptionId { get; set; }
		public List<CleaningCommand> CleaningCommand { get; set; }
		public List<Message> Messages { get; set; }
		public OrderStatus Status { get; set; }
		public bool IsApprovedOrder { get; set; } = false;
	}

	public enum OrderStatus
	{
		WaitManagerConfirm,
		FormCleanerCommand,
		WaitingCleaning,
		Cleaning,
		EvaluateWork,
		OrderCompleted
	}
}