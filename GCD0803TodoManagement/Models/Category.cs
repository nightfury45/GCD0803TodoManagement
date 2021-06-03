using GCD0803TodoManagement.UniqueAttribute;
using System.ComponentModel.DataAnnotations;

namespace GCD0803TodoManagement.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		[Unique(ErrorMessage = "Category already exist !!")]
		public string Name { get; set; }
	}
}