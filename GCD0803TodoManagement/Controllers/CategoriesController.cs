using GCD0803TodoManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	[Authorize]
	public class CategoriesController : Controller
	{
		private ApplicationDbContext _context;
		public CategoriesController()
		{
			_context = new ApplicationDbContext();
		}
		[Authorize(Roles = "manager, user")]
		// GET: Categories
		public ActionResult Index()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
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