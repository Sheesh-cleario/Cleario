namespace Core.Entities
{
	public class UserMessage
	{
		public int UserMessageId { get; set; }
		public string Comment { get; set; }
		public List<string> FilesUrl { get; set; }
	}
}