namespace Core.Entities
{
	public class CleaningCommand
	{
		public int CleaningCommandId { get; set; }
		public List<CleanerTeamMember> MyProperty { get; set; }
		public bool IsApproved { get; set; }
		public string Instruments { get; set; }
		public string Services { get; set; }
	}
}