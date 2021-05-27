using GCD0803TodoManagement.Models;
using System.Collections.Generic;

namespace GCD0803TodoManagement.ViewModels
{
	public class TodoCategoriesViewModel
	{
		public Todo Todo { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}