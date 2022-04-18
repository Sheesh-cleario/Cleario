namespace Core.Entities
{
	public class CleaningTask
	{
		public int CleaningTaskId { get; set; }
		public bool IsDone { get; set; } = false;
		public string TaskDescription { get; set; }
	}
}