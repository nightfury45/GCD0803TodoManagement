using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCD0803TodoManagement.Models
{
	public class TeamUser
	{
		[Key]
		[Column(Order = 1)]
		[ForeignKey("Team")]
		public int TeamId { get; set; }
		public Team Team { get; set; }
		[Key]
		[Column(Order = 2)]
		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}