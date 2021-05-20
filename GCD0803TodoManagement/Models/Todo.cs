using System;

namespace GCD0803TodoManagement.Models
{
	public class Todo
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public string Category { get; set; }
	}
}