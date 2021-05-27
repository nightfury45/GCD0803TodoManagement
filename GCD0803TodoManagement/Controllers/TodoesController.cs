using GCD0803TodoManagement.Models;
using GCD0803TodoManagement.ViewModels;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
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
			var todoes = _context.Todoes
				.Include(t => t.Category)
				.ToList();
			if (!searchString.IsNullOrWhiteSpace())
			{
				todoes = todoes.Where(t => t.Description.Contains(searchString)).ToList();
			}

			return View(todoes);
		}

		public ActionResult Details(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var todo = _context.Todoes
				.Include(t => t.Category)
				.SingleOrDefault(t => t.Id == id);

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
			var viewModel = new TodoCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new TodoCategoriesViewModel()
				{
					Todo = todo,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}

			var newTodo = new Todo()
			{
				Description = todo.Description,
				CategoryId = todo.CategoryId,
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

			var viewModel = new TodoCategoriesViewModel()
			{
				Todo = todoInDb,
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Todo todo)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new TodoCategoriesViewModel()
				{
					Todo = todo,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}
			var todoInDb = _context.Todoes.SingleOrDefault(t => t.Id == todo.Id);

			if (todoInDb == null) return HttpNotFound();

			todoInDb.Description = todo.Description;
			todoInDb.DueDate = todo.DueDate;
			todoInDb.CategoryId = todo.CategoryId;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}