namespace Core.Entities
{
	public class CleanerTeamMember
	{
		public int CleanerTeamMemberId { get; set; }
		public CleanerInfo CleanerInfo { get; set; }
		public bool IsMain { get; set; }
		public bool IsApproved { get; set; }
	}
}