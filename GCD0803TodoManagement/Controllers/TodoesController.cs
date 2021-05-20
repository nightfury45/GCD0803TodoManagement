using GCD0803TodoManagement.Models;
using System;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	public class TodoesController : Controller
	{
		private Todo _todo;

		public TodoesController()
		{
			_todo = new Todo()
			{
				Id = 1,
				Category = "Family",
				Description = "Buy Milk",
				DueDate = DateTime.Now
			};
		}
		// GET: Todoes
		public ActionResult Index()
		{
			return View(_todo);
		}

		public ActionResult Details()
		{
			return View();
		}
	}
}