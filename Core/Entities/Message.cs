namespace Core.Entities
{
	public class Message
	{
		public int MessageID { get; set; }
		public UserMessage UserMessage { get; set; }
		public MessageType MessageType { get; set; }
		public SenderType Sender { get; set; }
		public DateTime SendTime { get; set; }
	}

	public enum MessageType
	{
		UserMessage,
		ChangeStatus
	}

	public enum SenderType
	{
		Customer,
		Manager,
		Cleaner
	}
}