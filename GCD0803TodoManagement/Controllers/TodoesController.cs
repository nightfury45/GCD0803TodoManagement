using GCD0803TodoManagement.Models;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Net;
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
		public ActionResult Index(string searchString)
		{
			var todoes = _context.Todoes.ToList();
			if (!searchString.IsNullOrWhiteSpace())
			{
				todoes = todoes.Where(t => t.Description.Contains(searchString)).ToList();
			}

			return View(todoes);
		}

		public ActionResult Details(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todo = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			return View(todo);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todo = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			_context.Todoes.Remove(todo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				return View(todo);
			}

			var newTodo = new Todo()
			{
				Description = todo.Description,
				Category = todo.Category,
				DueDate = todo.DueDate
			};

			_context.Todoes.Add(newTodo);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return HttpNotFound();

			return View(todoInDb);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				return View(todo);
			}
			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == todo.Id);

			if (todoInDb == null) return HttpNotFound();

			todoInDb.Description = todo.Description;
			todoInDb.DueDate = todo.DueDate;
			todoInDb.Category = todo.Category;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}