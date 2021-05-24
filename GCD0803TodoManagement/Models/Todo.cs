using System;
using System.ComponentModel.DataAnnotations;

namespace GCD0803TodoManagement.Models
{
	public class Todo
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public DateTime DueDate { get; set; }
		[Required]
		public string Category { get; set; }
	}
}