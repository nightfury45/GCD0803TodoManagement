using GCD0803TodoManagement.Models;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	[Authorize]
	public class CategoriesController : Controller
	{
		[Authorize(Roles = "manager, user")]
		// GET: Categories
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Authorize(Roles = "manager")]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "manager")]
		public ActionResult Create(Category category)
		{
			return RedirectToAction("Index");
		}
	}
}