using GCD0803TodoManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0803TodoManagement.Controllers
{
	public class TodoesController : Controller
	{
		private ApplicationDbContext _context; // use ApplicationDbContext class to connect to database

		public TodoesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Todoes
		public ActionResult Index()
		{
			var todoes = _context.Todoes.ToList();
			return View(todoes);
		}

		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();

			var todo = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		public ActionResult Create()
		{
			return View();
		}
	}
}