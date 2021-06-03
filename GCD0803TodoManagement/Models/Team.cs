using GCD0803TodoManagement.UniqueAttribute;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCD0803TodoManagement.Models
{
	public class Team
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		[Unique(ErrorMessage = "Team Name already exist !!")]
		[DisplayName("Team Name")]
		public string Name { get; set; }
	}
}