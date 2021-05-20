using GCD0803TodoManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	public class TodoesController : Controller
	{
		private List<Todo> _todoes;

		public TodoesController()
		{
			_todoes = new List<Todo>();
			_todoes.Add(new Todo()
			{
				Id = 1,
				Description = "Buy Milk",
				Category = "Family",
				DueDate = DateTime.Now
			});

			_todoes.Add(new Todo()
			{
				Id = 2,
				Description = "Kill Bill",
				Category = "Professional",
				DueDate = DateTime.Now
			});
		}
		// GET: Todoes
		public ActionResult Index()
		{
			return View(_todoes);
		}

		public ActionResult Details()
		{
			return View();
		}
	}
}