using GCD0803TodoManagement.Models;
using System.Collections.Generic;

namespace GCD0803TodoManagement.ViewModels
{
	public class TeamUsersViewModel
	{
		public int TeamId { get; set; }
		public string UserId { get; set; }
		public IEnumerable<ApplicationUser> Users { get; set; }
	}
}