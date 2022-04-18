namespace Core.Entities
{
	public class UserMessage
	{
		public int UserMessageId { get; set; }
		public string Comment { get; set; }
		public List<UploadedFile> Files { get; set; }
	}

	public class UploadedFile
	{
		public int UploadedFileId { get; set; }
		public string Url { get; set; }
	}
}